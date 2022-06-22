using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Queries
{
    public class GetRolePermissionByIds : SaanaaDbQueryByIds<RolePermission>
    {
        public GetRolePermissionByIds() : base("[Identity].[RolePermission]")
        {
        }
    }
}
