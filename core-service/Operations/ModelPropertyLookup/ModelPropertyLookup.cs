using Core.Meteor;
using Core.Meteor.Dto;

namespace Core.Operations.ModelPropertyLookup
{
    public class ModelPropertyLookup : BaseModelDto, IDropDown
    {
        public int ModelPropertyId { get; set; }
        public string? ModelPropertyTitle { get; set; }
        public string Title { get; set; }
        public int Value { get; set; }
        public bool? IsActive { get; set; }

    }
}
