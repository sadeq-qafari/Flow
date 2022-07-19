using Core.Meteor;

namespace Tenant.Operations.Pricing.Queries
{
    public class GetPricingExcel : DbQueryExcel<Pricing>
    {
        public GetPricingExcel() : base("[Tenant].[Pricing]")
        {
        }
    }
}