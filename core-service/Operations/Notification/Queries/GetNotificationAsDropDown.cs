using Core.Meteor;

namespace Core.Operations.Notification.Queries
{
    public class GetNotificationAsDropDown : DbQueryAsDropDown<Notification>
    {
        public GetNotificationAsDropDown() : base("[Base].[Notification]")
        {
        }
    }
}
