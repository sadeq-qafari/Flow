using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingItem.Queries
{
    public class GetPricingItem : SaanaaDbSelectAsync<PricingItem?>
    {
        public GetPricingItem() : base("[Tenant].[PricingItem]")
        {
        }
    }
}