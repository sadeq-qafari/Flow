using Core.Meteor;
using Core.Meteor.Dto;

namespace Core.Operations.ModelFilter
{
    public class ModelFilter : BaseModelDto, IDropDown
    {
        public string Title { get; set; }
        public int? ModelId { get; set; }
        public string FilterString { get; set; }
        public int TypeLookup { get; set; }
        public bool IsActive { get; set; }

    }
}
