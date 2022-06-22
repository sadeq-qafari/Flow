using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingDetailTenant.Queries
{
    public class GetPricingDetailTenantByIds : SaanaaDbQueryByIds<PricingDetailTenant>
    {
        public GetPricingDetailTenantByIds() : base("[Tenant].[PricingDetailTenant]")
        {
        }
    }
}