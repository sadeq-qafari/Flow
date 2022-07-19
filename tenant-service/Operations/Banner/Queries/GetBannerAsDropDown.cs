using Core.Meteor;

namespace Tenant.Operations.Banner.Queries
{
    public class GetBannerAsDropDown : DbQueryAsDropDown<Banner>
    {
        public GetBannerAsDropDown() : base("[Tenant].[Banner]")
        {
        }
    }
}
