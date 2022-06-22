using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Banner
{
    public class Banner : BaseModelDto, IDropDown
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public ImageInfoJson Image { get; set; }
        public string? Description { get; set; }
        public string Link { get; set; }
        public bool IsLinkExternal { get; set; }
        public int Size { get; set; }
        public int Index { get; set; }
        public bool IsActive { get; set; }
    }
}
