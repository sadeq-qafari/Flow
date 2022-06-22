using Saanaa.Core.Meteor;
using Tenant.Operations.Banner.Dtos;

namespace Tenant.Operations.Banner.Queries
{
    public class GetBannerPage : SaanaaDbQueryPage<BannerDto>
    {
        public GetBannerPage() : base("[Tenant].[Banner]")
        {
        }
        
    }
}