using Core.Meteor;
using Core.Meteor.Dto;

namespace Identity.Operations.Database.Branch
{
    public class Branch : BaseModelDto, IDropDown
    {
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

    }
}
