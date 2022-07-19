using Core.Meteor;

namespace Tenant.Operations.PricingItem.Queries
{
    public class GetPricingItemAsDropDown : DbQueryAsDropDown<PricingItem>
    {
        public GetPricingItemAsDropDown() : base("[Tenant].[PricingItem]")
        {
        }
    }
}
