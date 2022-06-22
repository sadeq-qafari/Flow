using Saanaa.Core.Meteor;
using Tenant.Operations.PricingLog.Dtos;

namespace Tenant.Operations.PricingLog.Commands
{
    public class PricingLogUpdate : SaanaaDbUpdateAsync<PricingLogUpdateInDto>
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
