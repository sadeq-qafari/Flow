using Core.Operations.EntityRelation.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.EntityRelation.Commands
{
    public class AddEntityRelation : SaanaaDbInsertAsync<AddEntityRelationInDto>
    {
        public AddEntityRelation() : base("[Core].[EntityRelation]",
            "[ModelIdA], [EntityIdA], [ModelIdB], [EntityIdB]",
            "@ModelIdA, @EntityIdA, @ModelIdB, @EntityIdB")
        {
        }
    }
}

