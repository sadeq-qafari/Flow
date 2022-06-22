using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingDetail.Queries
{
    public class GetPricingDetailByIds : SaanaaDbQueryByIds<PricingDetail>
    {
        public GetPricingDetailByIds() : base("[Tenant].[PricingDetail]")
        {
        }
    }
}