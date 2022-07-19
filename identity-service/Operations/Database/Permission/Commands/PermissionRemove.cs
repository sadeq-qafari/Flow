using Core.Meteor;

namespace Identity.Operations.Database.Permission.Commands
{
    public class PermissionRemove : DbDeleteAsync
    {
        public PermissionRemove() : base("[Identity].[Permission]")
        {
        }
    }
}
