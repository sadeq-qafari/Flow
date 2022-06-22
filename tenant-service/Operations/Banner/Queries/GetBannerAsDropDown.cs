using Saanaa.Core.Meteor;

namespace Tenant.Operations.Banner.Queries
{
    public class GetBannerAsDropDown : SaanaaDbQueryAsDropDown<Banner>
    {
        public GetBannerAsDropDown() : base("[Tenant].[Banner]")
        {
        }
    }
}
