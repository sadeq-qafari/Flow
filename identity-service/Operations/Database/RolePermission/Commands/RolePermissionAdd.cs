using Identity.Operations.Database.RolePermission.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Commands
{
    public class RolePermissionAdd : SaanaaDbInsertAsync<RolePermissionAddInDto>
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

