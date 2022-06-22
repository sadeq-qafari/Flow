using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingLog.Commands
{
    public class PricingLogRemove : SaanaaDbDeleteAsync
    {
        public PricingLogRemove() : base("[Tenant].[PricingLog]")
        {
        }
    }
}