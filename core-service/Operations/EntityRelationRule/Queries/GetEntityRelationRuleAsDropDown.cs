using Saanaa.Core.Meteor;

namespace Core.Operations.EntityRelationRule.Queries
{
    public class GetEntityRelationRuleAsDropDown : SaanaaDbQueryAsDropDown<EntityRelationRule>
    {
        public GetEntityRelationRuleAsDropDown() : base("[Core].[EntityRelationRule]")
        {
        }
    }
}
