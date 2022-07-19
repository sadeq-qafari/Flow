using Identity.Operations.Database.RolePermission.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Commands
{
    public class RolePermissionUpdate : DbUpdateAsync<RolePermissionUpdateInDto>
    {
        public RolePermissionUpdate() : base("[Identity].[RolePermission]",
            @"[RoleId]=@RoleId,
					[PermissionId]=@PermissionId")
        {
        }
    }
}
