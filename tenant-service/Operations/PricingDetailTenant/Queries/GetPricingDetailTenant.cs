using Core.Meteor;

namespace Tenant.Operations.PricingDetailTenant.Queries
{
    public class GetPricingDetailTenant : DbSelectAsync<PricingDetailTenant?>
    {
        public GetPricingDetailTenant() : base("[Tenant].[PricingDetailTenant]")
        {
        }
    }
}