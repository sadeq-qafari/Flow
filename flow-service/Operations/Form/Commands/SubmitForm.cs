using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Core.Meteor.Extensions;
using Dapper;
using Flow.Core;
using Flow.Operations.Form.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Flow.Operations.Form.Commands
{
    public class SubmitForm : DbOperationAsync<SubmitFormInDto, SubmitFormDto>
    {
        protected override async Task ExecutionAsync()
        {
            var data = Input.Data.Select(leadData =>
                new SubmitFormData()
                {
                    FormPropertyId = FlowForms.GetForm(Input.FormName)?.Properties?
                        .FirstOrDefault(x => x.Name == leadData.Key)?
                        .Id ?? 0,
                    Value = leadData.Value?.ToString()
                });

            var dt = data?.AsDataTable("Flow.udt_FormLeadData", x => new
            {
                x.FormPropertyId,
                x.Value
            }) ?? new DataTable();

            var formId = FlowForms.GetForm(Input.FormName)?.Id ?? throw Errors.NotFound("form_not_found");

            var parameters = new DynamicParameters();
            parameters.Add("FormId", formId);
            parameters.Add("FormLeadId", Input.Id);
            parameters.Add("Data", dt.AsTableValuedParameter("Flow.udt_FormLeadData"));
            parameters.Add("CheckForDuplicate", Input.CheckForDuplicate);
            parameters.Add("CreatedBy", Input.ActionBy);
            parameters.Add("TenantId", Input.TenantId);

            var grid = await NewSql(@"EXECUTE Flow.sp_FormLeadDataUpsert 
                                   @FormId = @FormId
                                  ,@FormLeadId = @FormLeadId
                                  ,@Data = @Data
                                  ,@CheckForDuplicate = @CheckForDuplicate
                                  ,@CreatedBy = @CreatedBy
                                  ,@TenantId = @TenantId", parameters)
                .QueryMultipleAsync();
            var id = await grid.ReadFirstOrDefaultAsync<int>();
            var similarData = id > 0 ? null : await grid.ReadAsync<object>();
            Output = new SubmitFormDto() { Id = id, SimilarData = similarData };
        }
    }
}
