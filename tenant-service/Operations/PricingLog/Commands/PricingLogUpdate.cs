using Core.Meteor;
using Tenant.Operations.PricingLog.Dtos;

namespace Tenant.Operations.PricingLog.Commands
{
    public class PricingLogUpdate : DbUpdateAsync<PricingLogUpdateInDto>
    {
        public PricingLogUpdate() : base("[Tenant].[PricingLog]",
            @"[PricingItemId]=@PricingItemId,
					[Cost]=@Cost,
					[Percent]=@Percent,
					[Price]=@Price,
					[Date]=@Date,
					[ModelId]=@ModelId,
					[EntityId]=@EntityId")
        {
        }
    }
}
