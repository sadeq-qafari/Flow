using Identity.Operations.Database.RolePermission.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Commands
{
    public class RolePermissionAdd : DbInsertAsync<RolePermissionAddInDto>
    {
        public RolePermissionAdd() : base("[Identity].[RolePermission]",
            @"[RoleId],
						[PermissionId]",
            @"@RoleId,
						@PermissionId")
        {
        }
    }
}

