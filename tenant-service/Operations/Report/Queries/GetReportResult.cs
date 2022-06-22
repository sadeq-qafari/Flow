using System.Threading.Tasks;
using Meteor.Operation.Db;
using Tenant.Operations.Report.Dtos;

namespace Tenant.Operations.Report.Queries
{
    public class GetReportResult : DbOperationAsync<ReportResultInDto, object>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(Input.Query, Input.Params).QueryAsync<object>();
        }
    }
}
