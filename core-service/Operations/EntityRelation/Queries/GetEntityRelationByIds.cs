using Core.Meteor;

namespace Core.Operations.EntityRelation.Queries
{
    public class GetEntityRelationByIds : DbQueryByIds<EntityRelation>
    {
        public GetEntityRelationByIds() : base("[Core].[EntityRelation]")
        {
        }
    }
}
