using Core.Meteor.Dto;

namespace Core.Operations.EntityRelationRule.Dto
{
    public class AddEntityRelationRuleInDto : DbInsertInDto
    {
        public int ModelIdA { get; set; }
        public int ModelIdB { get; set; }
        public int RelationTypeLookup { get; set; }

    }
}
