using Identity.Operations.Database.UserPermission.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.UserPermission.Commands
{
    public class UserPermissionUpdate : SaanaaDbUpdateAsync<UserPermissionUpdateInDto>
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
