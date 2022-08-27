using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core.AspNetCore.Redis;
using Core.Meteor.Extensions;
using Dapper;
using Flow.Operations.Form.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Flow.Operations.Form.Commands;

public class BatchInsert : DbOperationAsync<BatchInsertInDto, bool>
{
    public RedisCache redis { get; set; }
    public string guidRegexPattern => "(\\d+_)*[({]?[a-fA-F0-9]{8}[-]?([a-fA-F0-9]{4}[-]?){3}[a-fA-F0-9]{12}[})]?";
    public Dictionary<int, List<FormLeadDataBatchInsertOutDto>> insertedFormData { get; set; } = new();

    protected override Task PrepareExecutionAsync()
    {
        redis = OperationFactory?.GetService<RedisCache>()
                ?? throw Errors.InvalidOperation("redis_is_not_registered");
        return Task.CompletedTask;
    }

    protected override async Task ExecutionAsync()
    {
        var dataDict = await redis.Get<Dictionary<int, List<FormDataModel>>>(Input.Reference);

        Output = await EnsureInTransactionAsync(async () =>
        {
            foreach (var item in dataDict.FirstOrDefault(x => x.Key == Input.FormId).Value)
            {
                if (item.Value is not null && Regex.IsMatch(item.Value, guidRegexPattern))
                {
                    var relatedFormId = item.Value.Split('_').FirstOrDefault();
                    var relatedFormKey = 0;
                    if (relatedFormId is not null)
                        relatedFormKey = int.Parse(relatedFormId);
                    else continue;
                    if (!Input.SelectedItems.ContainsKey(relatedFormKey))
                        Input.SelectedItems.Add(relatedFormKey, new List<string> { item.Value });
                    else if (!Input.SelectedItems[relatedFormKey].Contains(item.Value))
                        Input.SelectedItems[relatedFormKey].Add(item.Value);
                }
            }

            foreach (var (formId, formData) in dataDict.OrderBy(x => x.Key == Input.FormId))
            {
                if (formId == Input.FormId)
                {
                    var selfRelatedData = formData
                        .Where(x =>
                            Regex.IsMatch(x.Value, guidRegexPattern)
                            && int.Parse(x.Value.Split('_').First()) == Input.FormId
                        ).ToList();
                    selfRelatedData.AddRange(formData.Where(x=>selfRelatedData.Any(y=>y.Guid==x.Guid)));
                    if (selfRelatedData.Count > 0)
                    {
                        await InsertInDb(formId, formData.Where(x => !selfRelatedData.Contains(x)).ToList());
                        SetRelatedData(selfRelatedData);
                        await InsertInDb(formId, selfRelatedData);
                    }
                    else
                    {
                        SetRelatedData(formData);
                        await InsertInDb(formId, formData);
                    }
                }
                else
                {
                    await InsertInDb(formId, formData);
                }
            }

            return true;
        }, IsolationLevel.ReadCommitted);
    }

    private async Task InsertInDb(int formId, List<FormDataModel> formData)
    {
        var dt = formData.Where(x => Input.SelectedItems[formId].Any(y => y == x.Guid)).AsDataTable(
            "Flow.udt_FormLeadDataBatchInsert", x => new
            {
                x.Guid,
                x.FormPropertyId,
                x.Value
            });

        var parameters = new DynamicParameters();
        parameters.Add("Data", dt.AsTableValuedParameter("Flow.udt_FormLeadDataBatchInsert"));
        parameters.Add("FormId", formId);
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
            if (insertedFormData.ContainsKey(formId))
                insertedFormData[formId].AddRange(result.ToList());
            else
                insertedFormData.Add(formId, result.ToList());
        }
    }

    private void SetRelatedData(List<FormDataModel> formData)
    {
        foreach (var data in formData.OrderBy(x => Regex.IsMatch(x.Value, guidRegexPattern)))
        {
            if (data.Value is not null && Regex.IsMatch(data.Value, guidRegexPattern))
            {
                var relatedFormId = int.Parse(data.Value.Split('_').First());
                data.Value = insertedFormData[relatedFormId]
                    .FirstOrDefault(x => x.Guid == data.Value)?.Id
                    .ToString();
            }
        }
    }
}

public class FormLeadDataBatchInsertOutDto
{
    public int Id { get; set; }
    public string Guid { get; set; }
}