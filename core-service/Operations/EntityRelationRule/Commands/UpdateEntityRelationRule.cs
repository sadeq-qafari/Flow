using Core.Meteor;
using Core.Operations.EntityRelationRule.Dto;

namespace Core.Operations.EntityRelationRule.Commands
{
    public class UpdateEntityRelationRule : DbUpdateAsync<UpdateEntityRelationRuleInDto>
    {
        public UpdateEntityRelationRule() : base("[Core].[EntityRelationRule]",
            "[ModelIdA]=@ModelIdA, [ModelIdB]=@ModelIdB, [RelationTypeLookup]=@RelationTypeLookup")
        {
        }
    }
}
