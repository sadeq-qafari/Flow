using Core.Meteor;

namespace Core.Operations.Notification.Queries
{
    public class GetNotificationByIds : DbQueryByIds<Notification>
    {
        public GetNotificationByIds() : base("[Base].[Notification]")
        {
        }
    }
}
