using Core.Meteor;

namespace Tenant.Operations.Pricing.Commands
{
    public class PricingRemove : DbDeleteAsync
    {
        public PricingRemove() : base("[Tenant].[Pricing]")
        {
        }
    }
}