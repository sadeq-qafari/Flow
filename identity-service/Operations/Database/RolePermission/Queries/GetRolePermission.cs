using Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Queries
{
    public class GetRolePermission : DbSelectAsync<RolePermission?>
    {
        public GetRolePermission() : base("[Identity].[RolePermission]")
        {
        }
    }
}
