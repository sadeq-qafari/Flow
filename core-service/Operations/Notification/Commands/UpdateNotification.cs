using Core.Meteor;
using Core.Operations.Notification.Dto;

namespace Core.Operations.Notification.Commands
{
    public class UpdateNotification : DbUpdateAsync<UpdateNotificationInDto>
    {
        public UpdateNotification() : base("[Base].[Notification]",
            "[Name]=@Name, [Title]=@Title, [Description]=@Description, [ShouldPersist]=@ShouldPersist, [Method]=@Method, [Arg]=@Arg")
        {
        }
    }
}
