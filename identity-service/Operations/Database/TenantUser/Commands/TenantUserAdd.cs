using Identity.Operations.Database.TenantUser.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.TenantUser.Commands
{
    public class TenantUserAdd : DbInsertAsync<TenantUserAddInDto>
    {
        public TenantUserAdd() : base("[Identity].[TenantUser]",
            @"[BranchId],
						[UserId],
						[IsBanned],
						[IsDefault]",
            @"@BranchId,
						@UserId,
						@IsBanned,
						@IsDefault")
        {
        }
    }
}

