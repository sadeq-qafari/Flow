using Core.Meteor;
using Tenant.Operations.PricingItem.Dtos;

namespace Tenant.Operations.PricingItem.Queries
{
    public class GetPricingItemPage : DbQueryPage<PricingItemDto>
    {
        public GetPricingItemPage() : base("[Tenant].[PricingItem]")
        {
        }
        
    }
}