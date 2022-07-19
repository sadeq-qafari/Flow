using Core.Meteor;
using Tenant.Operations.Pricing.Dtos;

namespace Tenant.Operations.Pricing.Commands
{
    public class PricingUpdate : DbUpdateAsync<PricingUpdateInDto>
    {
        public PricingUpdate() : base("[Tenant].[Pricing]",
            @"[ApplicationId]=@ApplicationId,
					[Title]=@Title,
					[Price]=ISNULL(@Price,0),
					[FinalPrice]=ISNULL(@FinalPrice,0),
					[GiftAmount]=ISNULL(@GiftAmount,0),
					[Description]=@Description,
					[Duration]=@Duration")
        {
        }
    }
}
