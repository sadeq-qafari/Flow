using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingDetail.Queries
{
    public class GetPricingDetailExcel : SaanaaDbQueryExcel<PricingDetail>
    {
        public GetPricingDetailExcel() : base("[Tenant].[PricingDetail]")
        {
        }
    }
}