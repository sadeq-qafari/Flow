using Core.Meteor;

namespace Core.Operations.EntityRelationRule.Queries
{
    public class GetEntityRelationRuleByIds : DbQueryByIds<EntityRelationRule>
    {
        public GetEntityRelationRuleByIds() : base("[Core].[EntityRelationRule]")
        {
        }
    }
}
