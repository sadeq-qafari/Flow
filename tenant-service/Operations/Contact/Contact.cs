using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Contact
{
    public class Contact : BaseModelDto, IDropDown
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public int ModelId { get; set; }
        public int EntityId { get; set; }
        public bool IsActive { get; set; }

    }
}
