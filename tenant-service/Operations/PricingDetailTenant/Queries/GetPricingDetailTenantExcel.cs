using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingDetailTenant.Queries
{
    public class GetPricingDetailTenantExcel : SaanaaDbQueryExcel<PricingDetailTenant>
    {
        public GetPricingDetailTenantExcel() : base("[Tenant].[PricingDetailTenant]")
        {
        }
    }
}