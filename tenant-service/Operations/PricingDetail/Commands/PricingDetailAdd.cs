using Core.Meteor;
using Tenant.Operations.PricingDetail.Dtos;

namespace Tenant.Operations.PricingDetail.Commands
{
    public class PricingDetailAdd : DbInsertAsync<PricingDetailAddInDto>
    {
        public PricingDetailAdd() : base("[Tenant].[PricingDetail]",
            @"[PricingId],
						[Title],
						[PricingItemId],
						[Quantity],
						[Cost],
						[Percent],
						[FromPrice],
						[ToPrice],
						[TypeLookup]",
            @"@PricingId,
						@Title,
						@PricingItemId,
						@Quantity,
						@Cost,
						@Percent,
						@FromPrice,
						@ToPrice,
						@TypeLookup")
        {
        }
    }
}

