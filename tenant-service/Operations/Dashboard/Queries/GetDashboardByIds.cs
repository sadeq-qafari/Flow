using Core.Meteor;

namespace Tenant.Operations.Dashboard.Queries
{
    public class GetDashboardByIds : DbQueryByIds<Dashboard>
    {
        public GetDashboardByIds() : base("[Tenant].[Dashboard]")
        {
        }
    }
}