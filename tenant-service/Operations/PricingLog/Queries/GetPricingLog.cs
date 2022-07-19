using Core.Meteor;

namespace Tenant.Operations.PricingLog.Queries
{
    public class GetPricingLog : DbSelectAsync<PricingLog?>
    {
        public GetPricingLog() : base("[Tenant].[PricingLog]")
        {
        }
    }
}