using Core.Meteor;
using Core.Meteor.Dto;

namespace Core.Operations.EntityRelation
{
    public class EntityRelation : BaseModelDto, IDropDown
    {
        public int ModelIdA { get; set; }
        public int EntityIdA { get; set; }
        public int ModelIdB { get; set; }
        public int EntityIdB { get; set; }
        public bool? IsActive { get; set; }
       public string Title {get; set;}
    }
}
