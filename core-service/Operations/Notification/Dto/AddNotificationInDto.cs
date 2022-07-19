using Core.Meteor.Dto;

namespace Core.Operations.Notification.Dto
{
    public class AddNotificationInDto : DbInsertInDto
    {
        public string Name { get; set; }
        public string Title { get; }
        public string Description { get; set; }
        public bool ShouldPersist { get; set; }
        public string Method { get; set; }
        public string Arg { get; set; }
    }
}
