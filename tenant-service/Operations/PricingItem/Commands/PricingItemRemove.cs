using Core.Meteor;

namespace Tenant.Operations.PricingItem.Commands
{
    public class PricingItemRemove : DbDeleteAsync
    {
        public PricingItemRemove() : base("[Tenant].[PricingItem]")
        {
        }
    }
}