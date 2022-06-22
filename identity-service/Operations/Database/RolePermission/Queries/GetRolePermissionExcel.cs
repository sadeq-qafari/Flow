using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Queries
{
    public class GetRolePermissionExcel : SaanaaDbQueryExcel<RolePermission>
    {
        public GetRolePermissionExcel() : base("[Identity].[RolePermission]")
        {
        }
    }
}
