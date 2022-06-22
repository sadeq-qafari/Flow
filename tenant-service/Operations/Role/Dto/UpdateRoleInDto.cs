using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Role.Dto
{
    public class UpdateRoleInDto : SaanaaDbUpdateInDto
    {
        public string Title { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentTitle { get; set; }
        public int ParentId { get; set; }
        public string? ParentTitle { get; set; }

    }
}
