using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.Menu.Dto
{
    public class AddMenuInDto : SaanaaDbInsertInDto
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

    }
}
