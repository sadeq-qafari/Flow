using Core.Meteor;
using Core.Operations.Notification.Dto;

namespace Core.Operations.Notification.Commands
{
    public class AddNotification : DbInsertAsync<AddNotificationInDto>
    {

        public AddNotification() : base("[Base].[Notification]",
            "[Name], [Title], [Description], [ShouldPersist], [Method], [Arg]",
            "@Name, @Title, @UserId, @Description, @ShouldPersist, @Method, @Arg")
        {
        }
    }
}

