using Core.Meteor;
using Core.Meteor.Dto;

namespace Tenant.Operations.Role
{
    public class Role : BaseModelDto, IDropDown
    {
        public string Title { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentTitle { get; set; }
        public int ParentId { get; set; }
        public string? ParentTitle { get; set; }
        public bool IsActive { get; set; }

    }
}
