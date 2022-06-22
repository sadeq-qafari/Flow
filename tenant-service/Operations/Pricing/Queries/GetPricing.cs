using Saanaa.Core.Meteor;

namespace Tenant.Operations.Pricing.Queries
{
    public class GetPricing : SaanaaDbSelectAsync<Pricing?>
    {
        public GetPricing() : base("[Tenant].[Pricing]")
        {
        }
    }
}