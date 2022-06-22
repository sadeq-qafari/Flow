using Saanaa.Core.Meteor;
using Tenant.Operations.PricingTenant.Dtos;

namespace Tenant.Operations.PricingTenant.Commands
{
    public class PricingTenantUpdate : SaanaaDbUpdateAsync<PricingTenantUpdateInDto>
    {
        public PricingTenantUpdate() : base("[Tenant].[PricingTenant]",
            @"[PricingId]=@PricingId,
					[Title]=@Title,
					[FinalPrice]=@FinalPrice,
					[FromDate]=@FromDate,
					[ToDate]=@ToDate")
        {
        }
    }
}