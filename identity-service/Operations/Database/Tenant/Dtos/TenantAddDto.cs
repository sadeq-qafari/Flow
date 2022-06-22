using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.Tenant.Dtos
{
    public class TenantAddInDto : SaanaaDbInsertInDto
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
    }
}
