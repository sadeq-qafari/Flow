using Saanaa.Core.Meteor;

namespace Core.Operations.Notification.Commands
{
    public class RemoveNotification : SaanaaDbDeleteAsync
    {
        public RemoveNotification() : base("[Base].[Notification]")
        {
        }
    }
}
