using Core.Meteor;

namespace Tenant.Operations.DashboardReport.Queries
{
    public class GetDashboardReport : DbSelectAsync<DashboardReport?>
    {
        public GetDashboardReport() : base("[Tenant].[DashboardReport]")
        {
        }
    }
}