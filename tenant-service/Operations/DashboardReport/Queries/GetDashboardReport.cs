using Saanaa.Core.Meteor;

namespace Tenant.Operations.DashboardReport.Queries
{
    public class GetDashboardReport : SaanaaDbSelectAsync<DashboardReport?>
    {
        public GetDashboardReport() : base("[Tenant].[DashboardReport]")
        {
        }
    }
}