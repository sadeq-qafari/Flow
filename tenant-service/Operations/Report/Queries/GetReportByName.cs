using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Meteor.Operation.Db;
using Tenant.Operations.Report.Dtos;

namespace Tenant.Operations.Report.Queries
{
    public class GetReportByName : DbOperationAsync<ReportByNameInDto, List<object>>
    {
        protected override async Task ExecutionAsync()
        {
            var reports = await NewSql(sql => sql
                .Select("[Tenant].[Report] Report")
                .Where("Report.Name IN @ReportNames"), new
            {
                ReportNames = Input.ReportNames.Split(',')
            }).QueryAsync<Report>();

            Output = new List<object>();
            var parameters = new DynamicParameters();
            parameters.Add("Tenant_Id", Input.TenantId);
            foreach (var report in reports)
            {
                var res = await OperationFactory!.New<GetReportResult>()
                    .ExecuteAsync(new ReportResultInDto
                    {
                        Query = report.Query,
                        Params = parameters
                    });
                Output.Add(res);
            }
        }
    }
}