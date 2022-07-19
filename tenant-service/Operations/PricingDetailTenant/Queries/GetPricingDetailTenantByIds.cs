using Core.Meteor;

namespace Tenant.Operations.PricingDetailTenant.Queries
{
    public class GetPricingDetailTenantByIds : DbQueryByIds<PricingDetailTenant>
    {
        public GetPricingDetailTenantByIds() : base("[Tenant].[PricingDetailTenant]")
        {
        }
    }
}