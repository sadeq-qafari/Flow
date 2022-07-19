using Core.Meteor;

namespace Core.Operations.Notification.Commands
{
    public class RemoveNotification : DbDeleteAsync
    {
        public RemoveNotification() : base("[Base].[Notification]")
        {
        }
    }
}
