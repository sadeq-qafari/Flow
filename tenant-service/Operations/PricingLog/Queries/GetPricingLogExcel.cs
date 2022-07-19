using Core.Meteor;

namespace Tenant.Operations.PricingLog.Queries
{
    public class GetPricingLogExcel : DbQueryExcel<PricingLog>
    {
        public GetPricingLogExcel() : base("[Tenant].[PricingLog]")
        {
        }
    }
}