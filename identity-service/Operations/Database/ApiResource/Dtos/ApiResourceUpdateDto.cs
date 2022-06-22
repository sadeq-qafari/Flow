using NodaTime;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.ApiResource.Dtos
{
    public class ApiResourceUpdateInDto : SaanaaDbUpdateInDto
    {
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public Instant Created { get; set; }
        public Instant? Updated { get; set; }
        public Instant? LastAccessed { get; set; }
        public bool NonEditable { get; set; }
        public string? Properties { get; set; }
        public string? Claims { get; set; }
        public string? Scopes { get; set; }
        public string? Secrets { get; set; }

    }
}
