using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Permission.Commands
{
    public class PermissionRemove : SaanaaDbDeleteAsync
    {
        public PermissionRemove() : base("[Identity].[Permission]")
        {
        }
    }
}
