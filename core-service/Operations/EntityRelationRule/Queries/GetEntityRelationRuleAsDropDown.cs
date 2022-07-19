using Core.Meteor;

namespace Core.Operations.EntityRelationRule.Queries
{
    public class GetEntityRelationRuleAsDropDown : DbQueryAsDropDown<EntityRelationRule>
    {
        public GetEntityRelationRuleAsDropDown() : base("[Core].[EntityRelationRule]")
        {
        }
    }
}
