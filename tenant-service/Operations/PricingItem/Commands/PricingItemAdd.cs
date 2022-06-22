using Saanaa.Core.Meteor;
using Tenant.Operations.PricingItem.Dtos;

namespace Tenant.Operations.PricingItem.Commands
{
    public class PricingItemAdd : SaanaaDbInsertAsync<PricingItemAddInDto>
    {
        public PricingItemAdd() : base("[Tenant].[PricingItem]",
            @"[Title],
						[Name]",
            @"@Title,
						@Name")
        {
        }
    }
}

