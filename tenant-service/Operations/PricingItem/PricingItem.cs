using Core.Meteor;
using Core.Meteor.Dto;

namespace Tenant.Operations.PricingItem
{
    public class PricingItem : BaseModelDto, IDropDown
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }
}
