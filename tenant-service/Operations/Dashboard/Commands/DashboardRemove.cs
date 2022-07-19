using Core.Meteor;

namespace Tenant.Operations.Dashboard.Commands
{
    public class DashboardRemove : DbDeleteAsync
    {
        public DashboardRemove() : base("[Tenant].[Dashboard]")
        {
        }
    }
}