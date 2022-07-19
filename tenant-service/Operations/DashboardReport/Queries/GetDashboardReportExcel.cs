using Core.Meteor;

namespace Tenant.Operations.DashboardReport.Queries
{
    public class GetDashboardReportExcel : DbQueryExcel<DashboardReport>
    {
        public GetDashboardReportExcel() : base("[Tenant].[DashboardReport]")
        {
        }
    }
}