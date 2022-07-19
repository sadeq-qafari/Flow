using Core.Meteor;

namespace Tenant.Operations.PricingDetailTenant.Commands
{
    public class PricingDetailTenantRemove : DbDeleteAsync
    {
        public PricingDetailTenantRemove() : base("[Tenant].[PricingDetailTenant]")
        {
        }
    }
}