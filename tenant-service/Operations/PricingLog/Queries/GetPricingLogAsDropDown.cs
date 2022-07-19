using Core.Meteor;

namespace Tenant.Operations.PricingLog.Queries
{
    public class GetPricingLogAsDropDown : DbQueryAsDropDown<PricingLog>
    {
        public GetPricingLogAsDropDown() : base("[Tenant].[PricingLog]")
        {
        }
    }
}
