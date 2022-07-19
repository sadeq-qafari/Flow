using Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Queries
{
    public class GetRolePermissionByIds : DbQueryByIds<RolePermission>
    {
        public GetRolePermissionByIds() : base("[Identity].[RolePermission]")
        {
        }
    }
}
