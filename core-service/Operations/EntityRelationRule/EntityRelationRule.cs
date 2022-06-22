using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.EntityRelationRule
{
    public class EntityRelationRule : BaseModelDto, IDropDown
    {
        public int ModelIdA { get; set; }
        public int ModelIdB { get; set; }
        public int RelationTypeLookup { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
