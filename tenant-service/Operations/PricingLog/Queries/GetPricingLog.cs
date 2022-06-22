using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingLog.Queries
{
    public class GetPricingLog : SaanaaDbSelectAsync<PricingLog?>
    {
        public GetPricingLog() : base("[Tenant].[PricingLog]")
        {
        }
    }
}