using Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Commands
{
    public class RolePermissionRemove : DbDeleteAsync
    {
        public RolePermissionRemove() : base("[Identity].[RolePermission]")
        {
        }
    }
}
