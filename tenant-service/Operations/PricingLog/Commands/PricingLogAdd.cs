using Saanaa.Core.Meteor;
using Tenant.Operations.PricingLog.Dtos;

namespace Tenant.Operations.PricingLog.Commands
{
    public class PricingLogAdd : SaanaaDbInsertAsync<PricingLogAddInDto>
    {
        public PricingLogAdd() : base("[Tenant].[PricingLog]",
            @"
[PricingItemId],
[Percent],
[Price],						
[Cost],
[Discount],
[Date],
[ModelId],
[EntityId]",
            @"
@PricingItemId,
@Cost,
@Percent,
@Price,
@Date,
@ModelId,
@EntityId")
        {
        }
    }
}

