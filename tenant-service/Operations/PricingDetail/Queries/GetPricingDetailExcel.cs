using Core.Meteor;

namespace Tenant.Operations.PricingDetail.Queries
{
    public class GetPricingDetailExcel : DbQueryExcel<PricingDetail>
    {
        public GetPricingDetailExcel() : base("[Tenant].[PricingDetail]")
        {
        }
    }
}