using Saanaa.Core.Meteor;

namespace Tenant.Operations.Pricing.Queries
{
    public class GetPricingExcel : SaanaaDbQueryExcel<Pricing>
    {
        public GetPricingExcel() : base("[Tenant].[Pricing]")
        {
        }
    }
}