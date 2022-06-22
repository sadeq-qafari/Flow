using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingLog.Queries
{
    public class GetPricingLogAsDropDown : SaanaaDbQueryAsDropDown<PricingLog>
    {
        public GetPricingLogAsDropDown() : base("[Tenant].[PricingLog]")
        {
        }
    }
}
