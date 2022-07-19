using Core.Meteor;

namespace Tenant.Operations.PricingDetail.Queries
{
    public class GetPricingDetailByIds : DbQueryByIds<PricingDetail>
    {
        public GetPricingDetailByIds() : base("[Tenant].[PricingDetail]")
        {
        }
    }
}