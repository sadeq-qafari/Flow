using Core.Meteor;

namespace Tenant.Operations.Dashboard.Queries
{
    public class GetDashboardAsDropDown : DbQueryAsDropDown<Dashboard>
    {
        public GetDashboardAsDropDown() : base("[Tenant].[Dashboard]")
        {
        }
    }
}
