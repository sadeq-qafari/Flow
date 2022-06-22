using Core.Operations.EntityRelationRule.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.EntityRelationRule.Commands
{
    public class UpdateEntityRelationRule : SaanaaDbUpdateAsync<UpdateEntityRelationRuleInDto>
    {
        public UpdateEntityRelationRule() : base("[Core].[EntityRelationRule]",
            "[ModelIdA]=@ModelIdA, [ModelIdB]=@ModelIdB, [RelationTypeLookup]=@RelationTypeLookup")
        {
        }
    }
}
