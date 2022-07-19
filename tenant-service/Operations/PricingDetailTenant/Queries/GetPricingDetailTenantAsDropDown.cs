using Core.Meteor;

namespace Tenant.Operations.PricingDetailTenant.Queries
{
    public class GetPricingDetailTenantAsDropDown : DbQueryAsDropDown<PricingDetailTenant>
    {
        public GetPricingDetailTenantAsDropDown() : base("[Tenant].[PricingDetailTenant]")
        {
        }
    }
}
