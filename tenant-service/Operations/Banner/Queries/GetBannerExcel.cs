using Saanaa.Core.Meteor;

namespace Tenant.Operations.Banner.Queries
{
    public class GetBannerExcel : SaanaaDbQueryExcel<Banner>
    {
        public GetBannerExcel() : base("[Tenant].[Banner]")
        {
        }
    }
}