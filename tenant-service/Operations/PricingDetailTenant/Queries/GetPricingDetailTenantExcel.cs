using Core.Meteor;

namespace Tenant.Operations.PricingDetailTenant.Queries
{
    public class GetPricingDetailTenantExcel : DbQueryExcel<PricingDetailTenant>
    {
        public GetPricingDetailTenantExcel() : base("[Tenant].[PricingDetailTenant]")
        {
        }
    }
}