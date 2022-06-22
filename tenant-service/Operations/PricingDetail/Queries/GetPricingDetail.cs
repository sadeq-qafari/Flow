using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingDetail.Queries
{
    public class GetPricingDetail : SaanaaDbSelectAsync<PricingDetail?>
    {
        public GetPricingDetail() : base("[Tenant].[PricingDetail]")
        {
        }
    }
}