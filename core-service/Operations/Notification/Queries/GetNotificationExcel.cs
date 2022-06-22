using Saanaa.Core.Meteor;

namespace Core.Operations.Notification.Queries
{
    public class GetNotificationExcel : SaanaaDbQueryExcel<Notification>
    {
        public GetNotificationExcel() : base("[Base].[Notification]")
        {
        }
    }
}
