using Core.Meteor;
using Core.Meteor.Dto;

namespace Core.Operations.Menu
{
    public class Menu : BaseModelDto, IDropDown
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public string? ParentTitle { get; set; }
        public string? PermissionName { get; set; }
        public int Index { get; set; }
        public string? Link { get; set; }
        public string Icon { get; set; }
        public string ColorHex { get; set; }
        public bool IsActive { get; set; }

    }
}
