using System.Threading.Tasks;
using Flow.Operations.Form.Dtos;
using Meteor.Operation.Db;

namespace Flow.Operations.Form.Queries
{
    public class GetFormInfo : DbOperationAsync<int, FormInfoDto>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(@"EXECUTE Flow.sp_FormInfo @FormId = @FormId", new { FormId = Input })
                .QueryFirstOrDefaultAsync<FormInfoDto>();
        }
    }
}