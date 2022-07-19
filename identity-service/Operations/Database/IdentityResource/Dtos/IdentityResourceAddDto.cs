using NodaTime;
using Core.Meteor.Dto;

namespace Identity.Operations.Database.IdentityResource.Dtos
{
    public class IdentityResourceAddInDto : DbInsertInDto
    {
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public Instant Created { get; set; }
        public Instant? Updated { get; set; }
        public bool NonEditable { get; set; }
        public string? Claims { get; set; }
        public string? Properties { get; set; }

    }
}
