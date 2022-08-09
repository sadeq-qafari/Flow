using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core.Meteor.Extensions;
using Dapper;
using Flow.Operations.Form.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Flow.Operations.Form.Commands;

public class BatchInsert : DbOperationAsync<BatchInsertInDto, bool>
{
    protected override async Task ExecutionAsync()
    {
        var insertedFormData = new Dictionary<int, List<FormLeadDataBatchInsertOutDto>>();

        Output = await EnsureInTransactionAsync(async () =>
        {
            foreach (var (formId, formData) in Input.Data.OrderBy(x => x.Key != Input.FormId))
            {
                if (formId == Input.FormId)
                {
                    foreach (var data in formData)
                    {
                        if (data.Value is not null && Regex.IsMatch(data.Value,
                                "\\d*_[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$"))
                        {
                            var relatedFormId = int.Parse(data.Value.Split('_').First());
                            data.Value = insertedFormData[relatedFormId]
                                .FirstOrDefault(x => x.Guid == data.Value)?.Id
                                .ToString();
                        }
                    }
                }

                var dt = formData.AsDataTable("Flow.udt_FormLeadDataBatchInsert", x => new
                {
                    x.Guid,
                    x.FormPropertyId,
                    x.Value
                });

                var parameters = new DynamicParameters();
                parameters.Add("Data", dt.AsTableValuedParameter("Flow.udt_FormLeadDataBatchInsert"));
                parameters.Add("FormId", Input.FormId);
                parameters.Add("ActionBy", Input.ActionBy);
                parameters.Add("TenantId", Input.TenantId);

                var result = (await NewSql(
                    "EXECUTE Flow.sp_FormLeadDataBatchInsert @Data = @Data, @ActionBy = @ActionBy, @TenantId = @TenantId, @FormId = @FormId",
                    parameters).QueryAsync<FormLeadDataBatchInsertOutDto>())?.ToList();

                if (result is null || !result.Any())
                {
                    throw Errors.InternalError("batch_insert_failed");
                }
                else
                {
                    insertedFormData.Add(formId, result.ToList());
                }
            }

            return true;
        }, IsolationLevel.ReadCommitted);
    }
}

public class FormLeadDataBatchInsertOutDto
{
    public int Id { get; set; }
    public string Guid { get; set; }
}