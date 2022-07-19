using Core.Meteor;

namespace Tenant.Operations.PricingDetail.Queries
{
    public class GetPricingDetailAsDropDown : DbQueryAsDropDown<PricingDetail>
    {
        public GetPricingDetailAsDropDown() : base("[Tenant].[PricingDetail]")
        {
        }
    }
}
