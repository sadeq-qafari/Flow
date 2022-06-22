using Saanaa.Core.Meteor;

namespace Tenant.Operations.DashboardReport.Queries
{
    public class GetDashboardReportExcel : SaanaaDbQueryExcel<DashboardReport>
    {
        public GetDashboardReportExcel() : base("[Tenant].[DashboardReport]")
        {
        }
    }
}