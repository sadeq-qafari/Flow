using Saanaa.Core.Meteor;
using Tenant.Operations.PricingItem.Dtos;

namespace Tenant.Operations.PricingItem.Queries
{
    public class GetPricingItemPage : SaanaaDbQueryPage<PricingItemDto>
    {
        public GetPricingItemPage() : base("[Tenant].[PricingItem]")
        {
        }
        
    }
}