using Core.Meteor;

namespace Tenant.Operations.Pricing.Queries
{
    public class GetPricingByIds : DbQueryByIds<Pricing>
    {
        public GetPricingByIds() : base("[Tenant].[Pricing]")
        {
        }
    }
}