using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.Application
{
    public class Application : BaseModelDto, IDropDown
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Terms { get; set; }
        public int? GatewayDetailId { get; set; }
        public bool IsActive { get; set; }
    }
}
