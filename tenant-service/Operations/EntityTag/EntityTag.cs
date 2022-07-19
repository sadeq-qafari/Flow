using Core.Meteor;
using Core.Meteor.Dto;

namespace Tenant.Operations.EntityTag
{
    public class EntityTag : BaseModelDto, IDropDown
    {
        public int ModelId { get; set; }
        public int EntityId { get; set; }
        public int TagId { get; set; }
        public bool? IsActive { get; set; }
       public string Title {get; set;}
    }
}
