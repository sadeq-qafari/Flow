using NodaTime;
using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.Version.Dto
{
    public class UpdateVersionInDto : SaanaaDbUpdateInDto
    {
        public string Title { get; set; }
        public Instant ReleaseDate { get; set; }
        public string Description { get; set; }
        public int? ApplicationId { get; set; }
        public int? ServiceId { get; set; }
        public bool IsAndroid { get; set; }
        public bool IsIos { get; set; }
        public bool IsPwa { get; set; }
        public bool IsWeb { get; set; }
        public bool IsPanel { get; set; }
    }
}
