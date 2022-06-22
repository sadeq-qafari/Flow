using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.Tenant.Dtos
{
    public class TenantUpdateInDto : SaanaaDbUpdateInDto
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
    }
}
