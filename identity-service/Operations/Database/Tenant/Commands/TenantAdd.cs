using Identity.Operations.Database.Tenant.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Tenant.Commands
{
    public class TenantAdd : SaanaaDbInsertAsync<TenantAddInDto>
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

