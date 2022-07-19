using Core.Meteor;
using Core.Meteor.Dto;

namespace Flow.Operations.Form
{
    public class Form : BaseModelDto, IDropDown
    {
        public string? Name { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Layout { get; set; }
        public bool? IsAddable { get; set; }
        public bool? IsUpdatable { get; set; }
        public bool? IsDeletable { get; set; }
        public bool IsActive { get; set; }

    }
}
