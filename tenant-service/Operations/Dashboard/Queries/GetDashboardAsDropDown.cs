using Saanaa.Core.Meteor;

namespace Tenant.Operations.Dashboard.Queries
{
    public class GetDashboardAsDropDown : SaanaaDbQueryAsDropDown<Dashboard>
    {
        public GetDashboardAsDropDown() : base("[Tenant].[Dashboard]")
        {
        }
    }
}
