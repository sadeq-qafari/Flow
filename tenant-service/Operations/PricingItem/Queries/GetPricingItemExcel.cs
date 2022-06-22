using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingItem.Queries
{
    public class GetPricingItemExcel : SaanaaDbQueryExcel<PricingItem>
    {
        public GetPricingItemExcel() : base("[Tenant].[PricingItem]")
        {
        }
    }
}