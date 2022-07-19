using Identity.Operations.Database.TenantUser.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.TenantUser.Commands
{
    public class TenantUserUpdate : DbUpdateAsync<TenantUserUpdateInDto>
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
