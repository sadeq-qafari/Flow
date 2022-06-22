using Saanaa.Core.Meteor;

namespace Tenant.Operations.Pricing.Queries
{
    public class GetPricingAsDropDown : SaanaaDbQueryAsDropDown<Pricing>
    {
        public GetPricingAsDropDown() : base("[Tenant].[Pricing]")
        {
        }
    }
}
