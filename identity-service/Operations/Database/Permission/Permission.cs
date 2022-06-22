using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.Permission
{
    public class Permission : BaseModelDto, IDropDown
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int TypeLookup { get; set; }
        public bool IsActive { get; set; }

    }
}
