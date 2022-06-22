using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingTenant.Queries
{
    public class GetPricingTenantAsDropDown : SaanaaDbQueryAsDropDown<PricingTenant>
    {
        public GetPricingTenantAsDropDown() : base("[Tenant].[PricingTenant]")
        {
        }
    }
}
