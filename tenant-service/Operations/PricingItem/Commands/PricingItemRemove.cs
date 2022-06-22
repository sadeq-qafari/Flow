using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingItem.Commands
{
    public class PricingItemRemove : SaanaaDbDeleteAsync
    {
        public PricingItemRemove() : base("[Tenant].[PricingItem]")
        {
        }
    }
}