using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingTenant.Queries
{
    public class GetPricingTenantByIds : SaanaaDbQueryByIds<PricingTenant>
    {
        public GetPricingTenantByIds() : base("[Tenant].[PricingTenant]")
        {
        }
    }
}