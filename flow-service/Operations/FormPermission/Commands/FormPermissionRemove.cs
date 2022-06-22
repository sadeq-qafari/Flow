using Saanaa.Core.Meteor;

namespace Flow.Operations.FormPermission.Commands
{
    public class FormPermissionRemove : SaanaaDbDeleteAsync
    {
        public FormPermissionRemove() : base("[Flow].[FormPermission]")
        {
        }
    }
}