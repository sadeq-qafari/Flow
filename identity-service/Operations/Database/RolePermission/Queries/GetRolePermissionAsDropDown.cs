using Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Queries
{
    public class GetRolePermissionAsDropDown : DbQueryAsDropDown<RolePermission>
    {
        public GetRolePermissionAsDropDown() : base("[Identity].[RolePermission]")
        {
        }
    }
}
