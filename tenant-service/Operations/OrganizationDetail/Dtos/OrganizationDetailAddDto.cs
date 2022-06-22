using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.OrganizationDetail.Dtos
{
    public class OrganizationDetailAddInDto : SaanaaDbInsertInDto
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string Type { get; set; }

    }
}
