using Saanaa.Core.Meteor;

namespace Core.Operations.EntityRelationRule.Queries
{
    public class GetEntityRelationRuleByIds : SaanaaDbQueryByIds<EntityRelationRule>
    {
        public GetEntityRelationRuleByIds() : base("[Core].[EntityRelationRule]")
        {
        }
    }
}
