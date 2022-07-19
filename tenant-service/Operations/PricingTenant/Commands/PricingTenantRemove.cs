using Core.Meteor;

namespace Tenant.Operations.PricingTenant.Commands
{
    public class PricingTenantRemove : DbDeleteAsync
    {
        public PricingTenantRemove() : base("[Tenant].[PricingTenant]")
        {
        }
    }
}