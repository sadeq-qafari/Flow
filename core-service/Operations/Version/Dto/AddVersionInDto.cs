using Core.Meteor.Dto;
using NodaTime;

namespace Core.Operations.Version.Dto
{
    public class AddVersionInDto : DbInsertInDto
    {
        public Instant ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int? ApplicationId { get; set; }
        public int? ServiceId { get; set; }
        public bool IsAndroid { get; set; }
        public bool IsIos { get; set; }
        public bool IsPwa { get; set; }
        public bool IsWeb { get; set; }
        public bool IsPanel { get; set; }
    }
}
