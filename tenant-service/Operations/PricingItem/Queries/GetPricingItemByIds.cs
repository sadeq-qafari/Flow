using Core.Meteor;

namespace Tenant.Operations.PricingItem.Queries
{
    public class GetPricingItemByIds : DbQueryByIds<PricingItem>
    {
        public GetPricingItemByIds() : base("[Tenant].[PricingItem]")
        {
        }
    }
}