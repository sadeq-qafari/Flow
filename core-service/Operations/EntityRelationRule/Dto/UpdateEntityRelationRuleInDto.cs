using Core.Meteor.Dto;

namespace Core.Operations.EntityRelationRule.Dto
{
    public class UpdateEntityRelationRuleInDto : DbUpdateInDto
    {
        public int ModelIdA { get; set; }
        public int ModelIdB { get; set; }
        public int RelationTypeLookup { get; set; }

    }
}
