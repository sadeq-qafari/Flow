using Core.Meteor;

namespace Tenant.Operations.PricingTenant.Queries
{
    public class GetPricingTenant : DbSelectAsync<PricingTenant?>
    {
        public GetPricingTenant() : base("[Tenant].[PricingTenant]")
        {
        }
    }
}