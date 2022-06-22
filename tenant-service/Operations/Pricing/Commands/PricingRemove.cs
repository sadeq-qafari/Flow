using Saanaa.Core.Meteor;

namespace Tenant.Operations.Pricing.Commands
{
    public class PricingRemove : SaanaaDbDeleteAsync
    {
        public PricingRemove() : base("[Tenant].[Pricing]")
        {
        }
    }
}