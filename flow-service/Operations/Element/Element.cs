using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.Element
{
    public class Element : BaseModelDto, IDropDown
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? Config { get; set; }
        public string? AcceptableTypes { get; set; }
        public string? ComponentName { get; set; }
        public bool IsActive { get; set; }

    }
}
