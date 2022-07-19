using Core.Meteor;
using Core.Meteor.Dto;

namespace Flow.Operations.Lookup
{
    public class Lookup : BaseModelDto, IDropDown
    {
        public string Title { get; set; }
        public int TypeLookup { get; set; }
        public string? Query { get; set; }
        public int? WebServiceId { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

    }
}
