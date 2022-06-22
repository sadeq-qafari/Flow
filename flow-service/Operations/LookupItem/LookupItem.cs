using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.LookupItem
{
    public class LookupItem : BaseModelDto, IDropDown
    {
        public int LookupId { get; set; }
        public string Title { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
        public int Index { get; set; }
        public string? Icon { get; set; }
        public string? ColorHex { get; set; }
        public bool IsActive { get; set; }

    }
}
