using Core.Operations.Notification.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.Notification.Commands
{
    public class AddNotification : SaanaaDbInsertAsync<AddNotificationInDto>
    {

        public AddNotification() : base("[Base].[Notification]",
            "[Name], [Title], [Description], [ShouldPersist], [Method], [Arg]",
            "@Name, @Title, @UserId, @Description, @ShouldPersist, @Method, @Arg")
        {
        }
    }
}

