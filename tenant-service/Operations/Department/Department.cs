using Core.Meteor;
using Core.Meteor.Dto;

namespace Tenant.Operations.Department
{
    public class Department : BaseModelDto, IDropDown
    {
        public int ParentId { get; set; }
        public string? ParentTitle { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

    }
}
