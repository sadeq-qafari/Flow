using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.AspNetCore.Redis;
using Core.Common.Extensions;
using Flow.Core;
using Flow.Core.Models;
using Flow.Operations.Form.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;
using OfficeOpenXml;

namespace Flow.Operations.Form.Commands
{
    public class ImportExcel : DbOperationAsync<ImportExcelInDto, ImportExcelDto>
    {
        private List<FormModel> relatedForms = new();
        private List<FormPropertyModel> relatedProperties = new();
        private Dictionary<int, List<FormDataModel>> dataDict = new();
        private FormModel form = new();
        public RedisCache redis { get; set; }

        protected override async Task ExecutionAsync()
        {
            try
            {
                // Get form
                form = FlowForms.GetForm(Input.FormName) ?? throw Errors.InvalidInput("form_not_found");
                dataDict.Add(form.Id, new List<FormDataModel>());

                // Get related forms
                foreach (var formProperty in form.Properties!.Where(x => x.RelatedFormId > 0))
                {
                    var relatedForm = FlowForms.GetForm(formProperty.RelatedFormId);
                    if (relatedForm is null) continue;
                    relatedForms.Add(relatedForm);
                    relatedProperties.Add(formProperty);
                }

                await using (var ms = new MemoryStream())
                {
                    // Copy file to memory stream
                    await Input.File!.CopyToAsync(ms);
                    using (ExcelPackage package = new ExcelPackage(ms))
                    {
                        // Read excel file
                        ExcelWorksheet? worksheet = null;
                        try
                        {
                            worksheet = package.Workbook.Worksheets.FirstOrDefault();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw Errors.InvalidInput("could_not_read_file");
                        }

                        // Check file
                        if (worksheet == null)
                        {
                            throw Errors.InvalidInput("could_not_read_excel_file");
                        }

                        // Check rows count
                        var rowCount = worksheet.Dimension.Rows;
                        if (rowCount <= 1)
                            throw Errors.InvalidInput("excel_file_is_empty");

                        // Get cols index from col titles
                        var cols = new Dictionary<int, int>();

                        for (var colIndex = 1; colIndex <= form.Properties!.Count; colIndex++)
                        {
                            // Get header
                            var header = worksheet.Cells[1, colIndex]?.Value?.ToString()?.Trim();
                            // Check header
                            if (string.IsNullOrEmpty(header)) continue;
                            // Get stripped header title
                            var title = header.Replace(" ", string.Empty);
                            // Find form property
                            var formProperty =
                                form
                                    .Properties
                                    .FirstOrDefault(x => x.Title.Replace(" ", string.Empty) == title);
                            // Check form property
                            if (formProperty is null)
                                continue;
                            // Set col index
                            cols.Add(formProperty.Id, colIndex);
                        }

                        /*
                         * if form property is related to other form
                         *  another data pack should be built
                         */
                        for (var rowIndex = 2; rowIndex <= rowCount; rowIndex++)
                        {
                            var rowGuid = Guid.NewGuid().ToString();
                            foreach (var (formPropertyId, colIndex) in cols)
                            {
                                var fieldValue = worksheet.Cells[rowIndex, colIndex].Value?.ToString();

                                var relatedProp = relatedProperties.FirstOrDefault(x => x.Id == formPropertyId);
                                if (relatedProp is not null)
                                {
                                    fieldValue = await AddToRelatedPack(relatedProp, fieldValue);
                                }

                                var relatedLookup = form.Properties.FirstOrDefault(x => x.Id == formPropertyId)?.Lookup;
                                if (relatedLookup is not null)
                                {
                                    fieldValue = relatedLookup.Options
                                        .FirstOrDefault(x => x.Title.Trim() == fieldValue.Trim())?.Value;
                                }

                                dataDict[form.Id].Add(new FormDataModel()
                                {
                                    Guid = rowGuid,
                                    FormPropertyId = formPropertyId,
                                    Value = fieldValue
                                });
                            }
                        }
                    }


                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Close();
                }

                // Build forms object 
                var formsObj = new Dictionary<string, List<Dictionary<string, string?>>>();

                foreach (var item in dataDict)
                {
                    // Get form by its id
                    var formItem = FlowForms.GetForm(item.Key)!;
                    var data = new List<Dictionary<string, string>>();
                    var rows = item.Value.GroupBy(x => x.Guid);
                    foreach (var row in rows)
                    {
                        // Build row and Set guid as id in each row
                        var rowDict = new Dictionary<string, string?>
                        {
                            { "Id", row.Key }
                        };
                        // Add props to row
                        foreach (var dictProp in row)
                        {
                            // Get prop by its id
                            var formItemProperty =
                                formItem.Properties!.FirstOrDefault(x => x.Id == dictProp.FormPropertyId)!;
                            var formItemPropertyName = formItemProperty.Name!;

                            // Check if its related to another form
                            if (formItemProperty.RelatedFormPropertyId > 0)
                            {
                                var relatedData =
                                    // Get related form from dict
                                    dataDict.FirstOrDefault(x => x.Key == formItemProperty.RelatedFormId)
                                        // Get rows
                                        .Value
                                        // Get row by its guid
                                        .FirstOrDefault(x => x.Guid == dictProp.Value);
                                if (relatedData is not null && dictProp.Value?.Contains('-') == false)
                                {
                                    dataDict.FirstOrDefault(x => x.Key == formItemProperty.RelatedFormId)
                                        .Value.Remove(relatedData);
                                }

                                rowDict.Add(formItemProperty.RelatedFormName + formItemProperty.RelatedFormPropertyName,
                                    relatedData?.Value);
                            }

                            if (formItemProperty.Lookup is not null)
                            {
                                var lookupTitle = formItemProperty.Lookup.Options
                                    .FirstOrDefault(x => x.Value == dictProp.Value)?.Title;
                                rowDict.Add(formItemPropertyName + "Title", lookupTitle);
                            }

                            rowDict.Add(formItemPropertyName, dictProp.Value);
                        }

                        data.Add(rowDict!);
                    }

                    formsObj.Add(formItem.Name!, data);
                }

                foreach (var item in dataDict.Where(item => item.Value.Count <= 0))
                    dataDict.Remove(item.Key);

                foreach (var formName in formsObj.Keys.Where(formName => formsObj[formName].Count <= 0))
                    formsObj.Remove(formName);

                redis = OperationFactory?.GetService<RedisCache>()
                        ?? throw Errors.InvalidOperation("redis_is_not_registered");
                var redisKey =
                    $"flow:form_excel_import:{Input.TenantId}:{Input.ActionBy}:{Input.FormName}_{DateTime.Now.Ticks}";
                await redis.Set(redisKey, dataDict, TimeSpan.FromHours(8));
                Output = new ImportExcelDto
                {
                    Reference = redisKey,
                    Forms = formsObj
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task<string> AddToRelatedPack(FormPropertyModel relatedProp, string fieldValue)
        {
            var relatedForm = FlowForms.GetForm(relatedProp.RelatedFormId);
            if (relatedForm is null)
                return string.Empty;

            var relatedFormProperty = relatedForm.Properties!.First(x => x.Id == relatedProp.RelatedFormPropertyId);
            var guid = $"{relatedForm.Id}_{Guid.NewGuid()}";

            // check if data exists in db
            var fieldName = $"REPLACE([{relatedFormProperty.Name}],SPACE(1),N'')";
            var relatedData = await NewSql(
                    sql => sql.Select($"[Flow].[v_{relatedForm.Name}]")
                        .Where($"{fieldName}=@SearchValue AND TenantId=@TenantId"),
                    new
                    {
                        SearchValue = fieldValue.Replace(" ", string.Empty),
                        TenantId = Input.TenantId
                    })
                .QueryFirstOrDefaultAsync<object?>();

            if (relatedData is not null)
            {
                guid = relatedData?.ConvertToDictionary()["Id"]?.ToString() ?? "";
            }

            if (!dataDict.ContainsKey(relatedForm.Id)) dataDict.Add(relatedForm.Id, new List<FormDataModel>());
            if (dataDict[relatedForm.Id].Any(x => x.Value == fieldValue && x.FormPropertyId == relatedFormProperty.Id))
                return dataDict[relatedForm.Id]
                    .First(x => x.Value == fieldValue && x.FormPropertyId == relatedFormProperty.Id).Guid;

            dataDict[relatedForm.Id].Add(new FormDataModel
            {
                Guid = guid,
                FormPropertyId = relatedFormProperty.Id,
                Value = fieldValue
            });
            return guid;
        }
    }
}