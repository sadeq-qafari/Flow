using Core.Meteor;
using Tenant.Operations.Banner.Dtos;

namespace Tenant.Operations.Banner.Queries
{
    public class GetBannerPage : DbQueryPage<BannerDto>
    {
        public GetBannerPage() : base("[Tenant].[Banner]")
        {
        }
        
    }
}