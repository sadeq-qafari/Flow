using Core.Meteor;
using Core.Meteor.Dto;

namespace Tenant.Operations.Favorite
{
    public class Favorite : BaseModelDto, IDropDown
    {
        public int PersonId { get; set; }
        public int ModelId { get; set; }
        public int EntityId { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; }
    }
}