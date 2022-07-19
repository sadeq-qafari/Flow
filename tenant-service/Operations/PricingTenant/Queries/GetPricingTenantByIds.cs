using Core.Meteor;

namespace Tenant.Operations.PricingTenant.Queries
{
    public class GetPricingTenantByIds : DbQueryByIds<PricingTenant>
    {
        public GetPricingTenantByIds() : base("[Tenant].[PricingTenant]")
        {
        }
    }
}