using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Department.Dto
{
    public class UpdateDepartmentInDto : SaanaaDbUpdateInDto
    {
        public int ParentId { get; set; }
        public string? ParentTitle { get; set; }
        public string Title { get; set; }

    }
}
