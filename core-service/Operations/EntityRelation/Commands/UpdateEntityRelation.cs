using Core.Meteor;
using Core.Operations.EntityRelation.Dto;

namespace Core.Operations.EntityRelation.Commands
{
    public class UpdateEntityRelation : DbUpdateAsync<UpdateEntityRelationInDto>
    {
        public UpdateEntityRelation() : base("[Core].[EntityRelation]",
            "[ModelIdA]=@ModelIdA, [EntityIdA]=@EntityIdA, [ModelIdB]=@ModelIdB, [EntityIdB]=@EntityIdB")
        {
        }
    }
}
