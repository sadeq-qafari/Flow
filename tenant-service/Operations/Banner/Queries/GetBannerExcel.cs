using Core.Meteor;

namespace Tenant.Operations.Banner.Queries
{
    public class GetBannerExcel : DbQueryExcel<Banner>
    {
        public GetBannerExcel() : base("[Tenant].[Banner]")
        {
        }
    }
}