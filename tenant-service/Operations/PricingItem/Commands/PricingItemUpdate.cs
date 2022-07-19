using Core.Meteor;
using Tenant.Operations.PricingItem.Dtos;

namespace Tenant.Operations.PricingItem.Commands
{
    public class PricingItemUpdate : DbUpdateAsync<PricingItemUpdateInDto>
    {
        public PricingItemUpdate() : base("[Tenant].[PricingItem]",
            @"[Title]=@Title,
					[Name]=@Name")
        {
        }
    }
}