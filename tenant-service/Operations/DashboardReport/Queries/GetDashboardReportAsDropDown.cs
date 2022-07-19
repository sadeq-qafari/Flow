using Core.Meteor;

namespace Tenant.Operations.DashboardReport.Queries
{
    public class GetDashboardReportAsDropDown : DbQueryAsDropDown<DashboardReport>
    {
        public GetDashboardReportAsDropDown() : base("[Tenant].[DashboardReport]")
        {
        }
    }
}
