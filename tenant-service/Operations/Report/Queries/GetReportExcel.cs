using Core.Meteor;

namespace Tenant.Operations.Report.Queries
{
    public class GetReportExcel : DbQueryExcel<Report>
    {
        public GetReportExcel() : base("[Tenant].[Report]")
        {
        }
    }
}