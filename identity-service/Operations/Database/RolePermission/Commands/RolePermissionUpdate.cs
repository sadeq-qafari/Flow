using Identity.Operations.Database.RolePermission.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Commands
{
    public class RolePermissionUpdate : SaanaaDbUpdateAsync<RolePermissionUpdateInDto>
    {
        public RolePermissionUpdate() : base("[Identity].[RolePermission]",
            @"[RoleId]=@RoleId,
					[PermissionId]=@PermissionId")
        {
        }
    }
}
