using Core.Meteor;
using Core.Operations.EntityRelation.Dto;

namespace Core.Operations.EntityRelation.Commands
{
    public class AddEntityRelation : DbInsertAsync<AddEntityRelationInDto>
    {
        public AddEntityRelation() : base("[Core].[EntityRelation]",
            "[ModelIdA], [EntityIdA], [ModelIdB], [EntityIdB]",
            "@ModelIdA, @EntityIdA, @ModelIdB, @EntityIdB")
        {
        }
    }
}

