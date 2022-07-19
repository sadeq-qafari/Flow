using Core.Meteor;

namespace Core.Operations.EntityRelation.Queries
{
    public class GetEntityRelation : DbSelectAsync<EntityRelation?>
    {
        public GetEntityRelation() : base("[Core].[EntityRelation]")
        {
        }
    }
}
