using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingItem.Queries
{
    public class GetPricingItemByIds : SaanaaDbQueryByIds<PricingItem>
    {
        public GetPricingItemByIds() : base("[Tenant].[PricingItem]")
        {
        }
    }
}