using Saanaa.Core.Meteor;

namespace Tenant.Operations.Banner.Queries
{
    public class GetBanner : SaanaaDbSelectAsync<Banner?>
    {
        public GetBanner() : base("[Tenant].[Banner]")
        {
        }
    }
}