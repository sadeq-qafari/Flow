using Core.Operations.EntityRelation.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.EntityRelation.Commands
{
    public class UpdateEntityRelation : SaanaaDbUpdateAsync<UpdateEntityRelationInDto>
    {
        public UpdateEntityRelation() : base("[Core].[EntityRelation]",
            "[ModelIdA]=@ModelIdA, [EntityIdA]=@EntityIdA, [ModelIdB]=@ModelIdB, [EntityIdB]=@EntityIdB")
        {
        }
    }
}
