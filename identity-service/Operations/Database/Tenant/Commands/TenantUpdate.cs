using Identity.Operations.Database.Tenant.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.Tenant.Commands
{
    public class TenantUpdate : DbUpdateAsync<TenantUpdateInDto>
    {
        public TenantUpdate() : base("[Identity].[Tenant]",
            @"[Name]=@Name,
					[Title]=@Title")
        {
        }
    }
}
