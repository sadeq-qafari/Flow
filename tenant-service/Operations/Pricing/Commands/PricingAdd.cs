using Core.Meteor;
using Tenant.Operations.Pricing.Dtos;

namespace Tenant.Operations.Pricing.Commands
{
    public class PricingAdd : DbInsertAsync<PricingAddInDto>
    {
        public PricingAdd() : base("[Tenant].[Pricing]",
            @"[ApplicationId],
						[Title],
						[Price],
						[FinalPrice],
						[GiftAmount],
						[Description],
						[Duration]",
            @"@ApplicationId,
						@Title,
						ISNULL(@Price,0),
						ISNULL(@FinalPrice,0),
						ISNULL(@GiftAmount,0),
						@Description,
						@Duration")
        {
        }
    }
}

