using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingTenant.Commands
{
    public class PricingTenantRemove : SaanaaDbDeleteAsync
    {
        public PricingTenantRemove() : base("[Tenant].[PricingTenant]")
        {
        }
    }
}