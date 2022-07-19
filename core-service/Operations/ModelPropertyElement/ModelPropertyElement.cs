using Core.Meteor;
using Core.Meteor.Dto;

namespace Core.Operations.ModelPropertyElement
{
    public class ModelPropertyElement : BaseModelDto, IDropDown
    {
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Attributes { get; set; }

        public string Title => Name;
    }
}
