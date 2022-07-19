using Core.Meteor;

namespace Tenant.Operations.PricingLog.Queries
{
    public class GetPricingLogByIds : DbQueryByIds<PricingLog>
    {
        public GetPricingLogByIds() : base("[Tenant].[PricingLog]")
        {
        }
    }
}