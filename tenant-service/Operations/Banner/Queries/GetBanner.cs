using Core.Meteor;

namespace Tenant.Operations.Banner.Queries
{
    public class GetBanner : DbSelectAsync<Banner?>
    {
        public GetBanner() : base("[Tenant].[Banner]")
        {
        }
    }
}