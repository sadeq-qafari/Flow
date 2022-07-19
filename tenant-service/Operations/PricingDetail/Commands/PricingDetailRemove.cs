using Core.Meteor;

namespace Tenant.Operations.PricingDetail.Commands
{
    public class PricingDetailRemove : DbDeleteAsync
    {
        public PricingDetailRemove() : base("[Tenant].[PricingDetail]")
        {
        }
    }
}