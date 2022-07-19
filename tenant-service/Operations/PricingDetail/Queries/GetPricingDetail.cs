using Core.Meteor;

namespace Tenant.Operations.PricingDetail.Queries
{
    public class GetPricingDetail : DbSelectAsync<PricingDetail?>
    {
        public GetPricingDetail() : base("[Tenant].[PricingDetail]")
        {
        }
    }
}