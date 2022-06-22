using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.Role
{
    public class Role : BaseModelDto, IDropDown
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ServiceId { get; set; }
        public bool IsActive { get; set; }

    }
}
