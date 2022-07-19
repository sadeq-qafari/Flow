using Identity.Operations.Database.Tenant.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.Tenant.Commands
{
    public class TenantAdd : DbInsertAsync<TenantAddInDto>
    {
        public TenantAdd() : base("[Identity].[Tenant]",
            @"[Name],
						[Title]",
            @"@Name,
						@Title")
        {
        }
    }
}

