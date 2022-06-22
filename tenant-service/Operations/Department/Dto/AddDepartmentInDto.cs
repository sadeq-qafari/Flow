using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Department.Dto
{
    public class AddDepartmentInDto : SaanaaDbInsertInDto
    {
        public int ParentId { get; set; }
        public string? ParentTitle { get; set; }
        public string Title { get; set; }

    }
}
