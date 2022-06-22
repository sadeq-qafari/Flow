using Saanaa.Core.Meteor;

namespace Tenant.Operations.Dashboard.Queries
{
    public class GetDashboardByIds : SaanaaDbQueryByIds<Dashboard>
    {
        public GetDashboardByIds() : base("[Tenant].[Dashboard]")
        {
        }
    }
}