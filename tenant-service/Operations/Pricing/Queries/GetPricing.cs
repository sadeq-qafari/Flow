using Core.Meteor;

namespace Tenant.Operations.Pricing.Queries
{
    public class GetPricing : DbSelectAsync<Pricing?>
    {
        public GetPricing() : base("[Tenant].[Pricing]")
        {
        }
    }
}