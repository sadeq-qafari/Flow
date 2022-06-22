using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingDetail.Queries
{
    public class GetPricingDetailAsDropDown : SaanaaDbQueryAsDropDown<PricingDetail>
    {
        public GetPricingDetailAsDropDown() : base("[Tenant].[PricingDetail]")
        {
        }
    }
}
