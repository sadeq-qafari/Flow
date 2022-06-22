using Identity.Operations.Database.TenantUser.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantUser.Commands
{
    public class TenantUserUpdate : SaanaaDbUpdateAsync<TenantUserUpdateInDto>
    {
        public TenantUserUpdate() : base("[Identity].[TenantUser]",
            @"[BranchId]=@BranchId,
					[UserId]=@UserId,
					[IsBanned]=@IsBanned,
					[IsDefault]=@IsDefault")
        {
        }
    }
}
