using System.Threading.Tasks;
using Flow.Core;
using Flow.Operations.Form.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Flow.Operations.Form.Queries
{
    public class ReadForm : DbOperationAsync<ReadFormInDto, object>
    {
        protected override async Task ExecutionAsync()
        {
            var formName = SaanaaForms.GetForm(Input.FormName)?.Name ?? throw Errors.NotFound("form_not_found");

            Output = await NewSql(sql=>sql.Select($"[Flow].[v_{formName}]").Where("Id=@Id AND TenantId=@TenantId"))
                .QueryFirstOrDefaultAsync<object>();
        }
    }
}
