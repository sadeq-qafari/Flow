using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingDetailTenant.Commands
{
    public class PricingDetailTenantRemove : SaanaaDbDeleteAsync
    {
        public PricingDetailTenantRemove() : base("[Tenant].[PricingDetailTenant]")
        {
        }
    }
}