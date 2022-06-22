using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingDetailTenant.Queries
{
    public class GetPricingDetailTenant : SaanaaDbSelectAsync<PricingDetailTenant?>
    {
        public GetPricingDetailTenant() : base("[Tenant].[PricingDetailTenant]")
        {
        }
    }
}