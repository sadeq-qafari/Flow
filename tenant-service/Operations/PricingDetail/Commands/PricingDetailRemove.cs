using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingDetail.Commands
{
    public class PricingDetailRemove : SaanaaDbDeleteAsync
    {
        public PricingDetailRemove() : base("[Tenant].[PricingDetail]")
        {
        }
    }
}