using Core.Meteor;

namespace Tenant.Operations.DashboardReport.Queries
{
    public class GetDashboardReportByIds : DbQueryByIds<DashboardReport>
    {
        public GetDashboardReportByIds() : base("[Tenant].[DashboardReport]")
        {
        }
    }
}