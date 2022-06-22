using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Queries
{
    public class GetRolePermission : SaanaaDbSelectAsync<RolePermission?>
    {
        public GetRolePermission() : base("[Identity].[RolePermission]")
        {
        }
    }
}
