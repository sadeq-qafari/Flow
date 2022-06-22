using Identity.Operations.Database.UserRole.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.UserRole.Commands
{
    public class UserRoleUpdate : SaanaaDbUpdateAsync<UserRoleUpdateInDto>
    {
        public UserRoleUpdate() : base("[Identity].[UserRole]",
            @"[UserId]=@UserId,
					[RoleId]=@RoleId,
					[BranchId]=@BranchId,
					[IsDefault]=@IsDefault")
        {
        }
    }
}
