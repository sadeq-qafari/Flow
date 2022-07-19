using Core.Meteor;

namespace Core.Operations.Notification.Queries
{
    public class GetNotificationExcel : DbQueryExcel<Notification>
    {
        public GetNotificationExcel() : base("[Base].[Notification]")
        {
        }
    }
}
