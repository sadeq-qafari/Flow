using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Queries
{
    public class GetRolePermissionAsDropDown : SaanaaDbQueryAsDropDown<RolePermission>
    {
        public GetRolePermissionAsDropDown() : base("[Identity].[RolePermission]")
        {
        }
    }
}
