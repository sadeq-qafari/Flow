using Saanaa.Core.Meteor;

namespace Core.Operations.Notification.Queries
{
    public class GetNotification : SaanaaDbSelectAsync<Notification>
    {
        public GetNotification() : base("[Base].[Notification]")
        {
        }
    }
}
