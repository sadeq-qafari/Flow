using Saanaa.Core.Meteor;
using Tenant.Operations.PricingDetailTenant.Dtos;

namespace Tenant.Operations.PricingDetailTenant.Commands
{
    public class PricingDetailTenantAdd : SaanaaDbInsertAsync<PricingDetailTenantAddInDto>
    {
        public PricingDetailTenantAdd() : base("[Tenant].[PricingDetailTenant]",
            @"[PricingItemId],
						[PricingTenantId],
						[Cost],
						[Percent],
						[FromPrice],
						[ToPrice]",
            @"@PricingItemId,
						@PricingTenantId,
						@Cost,
						@Percent,
						@FromPrice,
						@ToPrice")
        {
        }
    }
}

