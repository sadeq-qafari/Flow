using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingItem.Queries
{
    public class GetPricingItemAsDropDown : SaanaaDbQueryAsDropDown<PricingItem>
    {
        public GetPricingItemAsDropDown() : base("[Tenant].[PricingItem]")
        {
        }
    }
}
