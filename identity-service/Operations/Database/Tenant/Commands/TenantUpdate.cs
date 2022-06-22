using Identity.Operations.Database.Tenant.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Tenant.Commands
{
    public class TenantUpdate : SaanaaDbUpdateAsync<TenantUpdateInDto>
    {
        public TenantUpdate() : base("[Identity].[Tenant]",
            @"[Name]=@Name,
					[Title]=@Title")
        {
        }
    }
}
