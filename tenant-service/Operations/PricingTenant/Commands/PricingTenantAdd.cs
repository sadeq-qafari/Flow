using Saanaa.Core.Meteor;
using Tenant.Operations.PricingTenant.Dtos;

namespace Tenant.Operations.PricingTenant.Commands
{
    public class PricingTenantAdd : SaanaaDbInsertAsync<PricingTenantAddInDto>
    {
        public PricingTenantAdd() : base("[Tenant].[PricingTenant]",
            @"[PricingId],
						[Title],
						[FinalPrice],
						[FromDate],
						[ToDate]",
            @"@PricingId,
						@Title,
						@FinalPrice,
						@FromDate,
						@ToDate")
        {
        }
    }
}

