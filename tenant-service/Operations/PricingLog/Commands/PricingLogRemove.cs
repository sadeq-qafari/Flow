using Core.Meteor;

namespace Tenant.Operations.PricingLog.Commands
{
    public class PricingLogRemove : DbDeleteAsync
    {
        public PricingLogRemove() : base("[Tenant].[PricingLog]")
        {
        }
    }
}