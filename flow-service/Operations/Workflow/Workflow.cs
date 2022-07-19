using Core.Meteor;
using Core.Meteor.Dto;

namespace Flow.Operations.Workflow
{
    public class Workflow : BaseModelDto, IDropDown
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

    }
}
