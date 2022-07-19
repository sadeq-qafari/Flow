using Core.Meteor;

namespace Core.Operations.Notification.Queries
{
    public class GetNotification : DbSelectAsync<Notification>
    {
        public GetNotification() : base("[Base].[Notification]")
        {
        }
    }
}
