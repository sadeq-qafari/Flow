using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Flow.Core;
using Flow.Operations.Form.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;
using OfficeOpenXml;
using Saanaa.Core.Meteor.Extensions;

namespace Flow.Operations.Form.Commands
{
    public class ImportFormData : DbOperationAsync<ImportFormDataInDto, bool>
    {
        protected override async Task<bool> ExecutionAsync()
        {
            var data = new List<FormDataModel>();
            var form = SaanaaForms.GetForm(Input.FormName) ?? throw Errors.InvalidInput("form_not_found");

            await using (var ms = new MemoryStream())
            {
                await Input.File!.CopyToAsync(ms);
                using (ExcelPackage package = new ExcelPackage(ms))
                {
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

                    if (worksheet == null)
                    {
                        throw Errors.InvalidInput("could_not_read_excel_file");
                    }
                    else
                    {
                        var rowCount = worksheet.Dimension.Rows;
                        if (rowCount <= 1)
                            throw Errors.InvalidInput("excel_file_is_empty");


                        var cols = new Dictionary<int, int>();

                        for (var i = 1; i <= form.Properties!.Count; i++)
                        {
                            if (string.IsNullOrEmpty(worksheet.Cells[1, i]?.Value?.ToString()?.Trim())) continue;

                            var title = worksheet.Cells[1, i].Value.ToString()!.Replace(" ", string.Empty);


                            var formProperty =
                                form
                                    .Properties //.Where(x => (x.RelatedFormPropertyId ?? 0) == 0 && (x.LookupId ?? 0) == 0)
                                    .FirstOrDefault(x => x.Title.Replace(" ", string.Empty) == title);
                            
                            if (formProperty == null)
                                continue;
                            
                            if (formProperty.RelatedFormId > 0)
                            {
                                
                            }

                            cols.Add(formProperty.Id, i);
                        }

                        for (var row = 2; row <= rowCount; row++)
                        {
                            var guid = Guid.NewGuid().ToString();
                            foreach (var (formPropertyId, col) in cols)
                            {
                                data.Add(new FormDataModel()
                                {
                                    Guid = guid,
                                    FormPropertyId = formPropertyId,
                                    Value = worksheet.Cells[row, col].Value.ToString()
                                });
                            }
                        }
                    }
                }


                ms.Seek(0, SeekOrigin.Begin);
                ms.Close();
            }

            var dt = data.AsDataTable("Flow.udt_FormLeadDataBatchInsert", x => new
            {
                x.Guid,
                x.FormPropertyId,
                x.Value
            });

            var parameters = new DynamicParameters();
            parameters.Add("Data", dt.AsTableValuedParameter("Flow.udt_FormLeadDataBatchInsert"));
            parameters.Add("FormId", form.Id);
            parameters.Add("ActionBy", Input.ActionBy);
            parameters.Add("TenantId", Input.TenantId);

            return await NewSql(
                "EXECUTE Flow.sp_FormLeadDataBatchInsert @Data = @Data, @ActionBy = @ActionBy, @TenantId = @TenantId, @FormId = @FormId",
                parameters).ExecuteAsync() > 0;
        }
    }
}