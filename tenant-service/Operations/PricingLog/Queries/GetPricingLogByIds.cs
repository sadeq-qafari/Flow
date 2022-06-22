using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingLog.Queries
{
    public class GetPricingLogByIds : SaanaaDbQueryByIds<PricingLog>
    {
        public GetPricingLogByIds() : base("[Tenant].[PricingLog]")
        {
        }
    }
}