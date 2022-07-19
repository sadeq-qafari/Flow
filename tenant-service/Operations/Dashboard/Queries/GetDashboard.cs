using Core.Meteor;

namespace Tenant.Operations.Dashboard.Queries
{
    public class GetDashboard : DbSelectAsync<Dashboard?>
    {
        public GetDashboard() : base("[Tenant].[Dashboard]")
        {
        }
    }
}