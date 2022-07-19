using Core.Meteor;

namespace Tenant.Operations.PricingTenant.Queries
{
    public class GetPricingTenantAsDropDown : DbQueryAsDropDown<PricingTenant>
    {
        public GetPricingTenantAsDropDown() : base("[Tenant].[PricingTenant]")
        {
        }
    }
}
