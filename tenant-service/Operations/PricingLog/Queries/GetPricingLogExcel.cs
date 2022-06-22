using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingLog.Queries
{
    public class GetPricingLogExcel : SaanaaDbQueryExcel<PricingLog>
    {
        public GetPricingLogExcel() : base("[Tenant].[PricingLog]")
        {
        }
    }
}