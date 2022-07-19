using Core.Meteor.Dto;

namespace Identity.Operations.Database.Tenant.Dtos
{
    public class TenantUpdateInDto : DbUpdateInDto
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
    }
}
