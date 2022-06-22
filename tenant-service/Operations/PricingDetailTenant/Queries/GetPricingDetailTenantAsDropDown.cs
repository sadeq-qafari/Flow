using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingDetailTenant.Queries
{
    public class GetPricingDetailTenantAsDropDown : SaanaaDbQueryAsDropDown<PricingDetailTenant>
    {
        public GetPricingDetailTenantAsDropDown() : base("[Tenant].[PricingDetailTenant]")
        {
        }
    }
}
