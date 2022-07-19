using Core.Meteor;

namespace Tenant.Operations.PricingItem.Queries
{
    public class GetPricingItem : DbSelectAsync<PricingItem?>
    {
        public GetPricingItem() : base("[Tenant].[PricingItem]")
        {
        }
    }
}