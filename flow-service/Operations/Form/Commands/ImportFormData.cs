using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Flow.Core;
using Flow.Core.Models;
using Flow.Operations.Form.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;
using OfficeOpenXml;

namespace Flow.Operations.Form.Commands
{
    public class ImportFormData : DbOperationAsync<ImportFormDataInDto, Dictionary<int, List<FormDataModel>>>
    {
        private List<FormModel> relatedForms = new();
        private List<FormPropertyModel> relatedProperties = new();
        private Dictionary<int, List<FormDataModel>> dataDict = new();
        private FormModel form = new();

        protected override async Task ExecutionAsync()
        {
            // Get form
            form = SaanaaForms.GetForm(Input.FormName) ?? throw Errors.InvalidInput("form_not_found");
            // Get related forms
            foreach (var formProperty in form.Properties!.Where(x => x.RelatedFormId > 0))
            {
                var relatedForm = SaanaaForms.GetForm(formProperty.RelatedFormId);
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
                                .Properties.Where(x => (x.RelatedFormPropertyId ?? 0) == 0 && (x.LookupId ?? 0) == 0)
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
                            var fieldValue = worksheet.Cells[rowIndex, colIndex].Value.ToString();

                            var relatedProp = relatedProperties.FirstOrDefault(x => x.Id == formPropertyId);
                            if (relatedProp is not null)
                            {
                                fieldValue = AddToRelatedPack(relatedProp, fieldValue);
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

            Output = dataDict;
        }

        private string AddToRelatedPack(FormPropertyModel relatedProp, string fieldValue)
        {
            var guid = $"{relatedProp.RelatedFormId}_{Guid.NewGuid()}";
            if (relatedProp.RelatedFormId > 0)
            {
                dataDict[form.Id].Add(new FormDataModel
                {
                    Guid = guid,
                    FormPropertyId = relatedProp.Id,
                    Value = fieldValue
                });
                return guid;
            }

            return string.Empty;
        }
    }
}