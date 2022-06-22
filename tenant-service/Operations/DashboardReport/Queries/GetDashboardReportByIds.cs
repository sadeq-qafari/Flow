using Saanaa.Core.Meteor;

namespace Tenant.Operations.DashboardReport.Queries
{
    public class GetDashboardReportByIds : SaanaaDbQueryByIds<DashboardReport>
    {
        public GetDashboardReportByIds() : base("[Tenant].[DashboardReport]")
        {
        }
    }
}