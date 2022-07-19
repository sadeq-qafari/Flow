using Core.Meteor;
using Tenant.Operations.PricingItem.Dtos;

namespace Tenant.Operations.PricingItem.Commands
{
    public class PricingItemAdd : DbInsertAsync<PricingItemAddInDto>
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

