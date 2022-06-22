using System.Collections.Generic;
using NodaTime;
using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.NotificationUser.Dto
{
    public class AddNotificationUserInDto : SaanaaDbInsertInDto
    {
        public int UserId { get; set; }
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Dictionary<string, object> Arg { get; set; }
        public bool IsSeen { get; set; }
        public Instant SeenAt { get; set; }
    }
}
