using NodaTime;
using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.PersistedGrant
{
    public class PersistedGrant : BaseModelDto, IDropDown
    {
        public string? Key  { get; set; }
        public string? Type  { get; set; }
        public string? SubjectId  { get; set; }
        public string? ClientId  { get; set; }
        public Instant CreationTime  { get; set; }
        public Instant? Expiration  { get; set; }
        public string? Data  { get; set; }
        public string? SessionId  { get; set; }
        public string? Description  { get; set; }
        public Instant? ConsumedTime  { get; set; }
        public string? Title { get; set; }
    }
}
