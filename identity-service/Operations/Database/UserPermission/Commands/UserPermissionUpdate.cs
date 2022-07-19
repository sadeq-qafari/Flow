using Identity.Operations.Database.UserPermission.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.UserPermission.Commands
{
    public class UserPermissionUpdate : DbUpdateAsync<UserPermissionUpdateInDto>
    {
        public UserPermissionUpdate() : base("[Identity].[UserPermission]",
            @"[UserId]=@UserId,
					[PermissionId]=@PermissionId,
					[BranchId]=@BranchId,
					[IsGranted]=@IsGranted")
        {
        }
    }
}
