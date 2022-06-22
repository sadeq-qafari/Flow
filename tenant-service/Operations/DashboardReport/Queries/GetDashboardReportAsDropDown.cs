using Saanaa.Core.Meteor;

namespace Tenant.Operations.DashboardReport.Queries
{
    public class GetDashboardReportAsDropDown : SaanaaDbQueryAsDropDown<DashboardReport>
    {
        public GetDashboardReportAsDropDown() : base("[Tenant].[DashboardReport]")
        {
        }
    }
}
