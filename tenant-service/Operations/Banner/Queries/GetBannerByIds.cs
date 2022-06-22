using Saanaa.Core.Meteor;

namespace Tenant.Operations.Banner.Queries
{
    public class GetBannerByIds : SaanaaDbQueryByIds<Banner>
    {
        public GetBannerByIds() : base("[Tenant].[Banner]")
        {
        }
    }
}