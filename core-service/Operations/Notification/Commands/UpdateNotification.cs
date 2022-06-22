using Core.Operations.Notification.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.Notification.Commands
{
    public class UpdateNotification : SaanaaDbUpdateAsync<UpdateNotificationInDto>
    {
        public UpdateNotification() : base("[Base].[Notification]",
            "[Name]=@Name, [Title]=@Title, [Description]=@Description, [ShouldPersist]=@ShouldPersist, [Method]=@Method, [Arg]=@Arg")
        {
        }
    }
}
