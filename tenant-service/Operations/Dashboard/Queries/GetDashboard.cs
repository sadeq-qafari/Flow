using Saanaa.Core.Meteor;

namespace Tenant.Operations.Dashboard.Queries
{
    public class GetDashboard : SaanaaDbSelectAsync<Dashboard?>
    {
        public GetDashboard() : base("[Tenant].[Dashboard]")
        {
        }
    }
}