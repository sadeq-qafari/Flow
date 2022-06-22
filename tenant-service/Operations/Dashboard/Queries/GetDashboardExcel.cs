using Saanaa.Core.Meteor;

namespace Tenant.Operations.Dashboard.Queries
{
    public class GetDashboardExcel : SaanaaDbQueryExcel<Dashboard>
    {
        public GetDashboardExcel() : base("[Tenant].[Dashboard]")
        {
        }
    }
}