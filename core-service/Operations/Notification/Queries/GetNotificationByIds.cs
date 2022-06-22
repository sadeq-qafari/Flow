using Saanaa.Core.Meteor;

namespace Core.Operations.Notification.Queries
{
    public class GetNotificationByIds : SaanaaDbQueryByIds<Notification>
    {
        public GetNotificationByIds() : base("[Base].[Notification]")
        {
        }
    }
}
