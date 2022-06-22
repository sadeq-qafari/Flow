using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.FormAction
{
    public class FormAction : BaseModelDto, IDropDown
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? ColorHex { get; set; }
        public int FormId { get; set; }
        public int TypeLookup { get; set; }
        public string? Script { get; set; }
        public bool IsActive { get; set; }

    }
}
