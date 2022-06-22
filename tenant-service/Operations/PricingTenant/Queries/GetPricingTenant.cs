using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingTenant.Queries
{
    public class GetPricingTenant : SaanaaDbSelectAsync<PricingTenant?>
    {
        public GetPricingTenant() : base("[Tenant].[PricingTenant]")
        {
        }
    }
}