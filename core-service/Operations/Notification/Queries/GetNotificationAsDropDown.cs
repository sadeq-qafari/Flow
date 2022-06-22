using Saanaa.Core.Meteor;

namespace Core.Operations.Notification.Queries
{
    public class GetNotificationAsDropDown : SaanaaDbQueryAsDropDown<Notification>
    {
        public GetNotificationAsDropDown() : base("[Base].[Notification]")
        {
        }
    }
}
