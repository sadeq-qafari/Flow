using System.Collections.Generic;

namespace Core.Models.SignalR
{
    public class SendNotificationInDto
    {
        public int NotificationId { get; set; }
        public bool Persist { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public Dictionary<string, object> Arg { get; set; }
    }
}
