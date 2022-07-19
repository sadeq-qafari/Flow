using Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Queries
{
    public class GetRolePermissionExcel : DbQueryExcel<RolePermission>
    {
        public GetRolePermissionExcel() : base("[Identity].[RolePermission]")
        {
        }
    }
}
