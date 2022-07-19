using Core.Meteor.Dto;

namespace Identity.Operations.Database.Tenant.Dtos
{
    public class TenantAddInDto : DbInsertInDto
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
    }
}
