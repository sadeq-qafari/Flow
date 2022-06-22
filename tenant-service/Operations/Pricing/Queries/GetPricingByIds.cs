using Saanaa.Core.Meteor;

namespace Tenant.Operations.Pricing.Queries
{
    public class GetPricingByIds : SaanaaDbQueryByIds<Pricing>
    {
        public GetPricingByIds() : base("[Tenant].[Pricing]")
        {
        }
    }
}