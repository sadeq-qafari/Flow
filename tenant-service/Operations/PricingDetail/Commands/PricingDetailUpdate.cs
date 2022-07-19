using Core.Meteor;
using Tenant.Operations.PricingDetail.Dtos;

namespace Tenant.Operations.PricingDetail.Commands
{
    public class PricingDetailUpdate : DbUpdateAsync<PricingDetailUpdateInDto>
    {
        public PricingDetailUpdate() : base("[Tenant].[PricingDetail]",
            @"[PricingId]=@PricingId,
					[PricingItemId]=@PricingItemId,
					[Quantity]=@Quantity,
					[Cost]=@Cost,
					[Percent]=@Percent,
					[FromPrice]=@FromPrice,
					[ToPrice]=@ToPrice,
					[TypeLookup]=@TypeLookup")
        {
        }
    }
}