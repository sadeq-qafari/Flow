using Core.Meteor;

namespace Flow.Operations.FormPermission.Commands
{
    public class FormPermissionRemove : DbDeleteAsync
    {
        public FormPermissionRemove() : base("[Flow].[FormPermission]")
        {
        }
    }
}