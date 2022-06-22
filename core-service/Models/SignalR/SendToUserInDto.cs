namespace Core.Models.SignalR
{
    public class SendToUserInDto : SendNotificationInDto
    {
        public int UserId { get; set; }
    }
}
