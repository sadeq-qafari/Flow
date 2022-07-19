using Core.Meteor;

namespace Tenant.Operations.PricingItem.Queries
{
    public class GetPricingItemExcel : DbQueryExcel<PricingItem>
    {
        public GetPricingItemExcel() : base("[Tenant].[PricingItem]")
        {
        }
    }
}