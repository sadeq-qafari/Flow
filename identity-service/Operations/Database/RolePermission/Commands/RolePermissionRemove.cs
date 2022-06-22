using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Commands
{
    public class RolePermissionRemove : SaanaaDbDeleteAsync
    {
        public RolePermissionRemove() : base("[Identity].[RolePermission]")
        {
        }
    }
}
