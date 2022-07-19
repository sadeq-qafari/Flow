using Core.Meteor;

namespace Tenant.Operations.Pricing.Queries
{
    public class GetPricingAsDropDown : DbQueryAsDropDown<Pricing>
    {
        public GetPricingAsDropDown() : base("[Tenant].[Pricing]")
        {
        }
    }
}
