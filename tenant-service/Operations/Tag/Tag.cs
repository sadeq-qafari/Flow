using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Tag
{
    public class Tag : BaseModelDto, IDropDown
    {
        public string? Title { get; set; }
        public bool? IsActive { get; set; }

    }
}
