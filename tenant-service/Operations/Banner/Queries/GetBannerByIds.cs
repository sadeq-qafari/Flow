using Core.Meteor;

namespace Tenant.Operations.Banner.Queries
{
    public class GetBannerByIds : DbQueryByIds<Banner>
    {
        public GetBannerByIds() : base("[Tenant].[Banner]")
        {
        }
    }
}