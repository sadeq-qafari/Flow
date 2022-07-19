using Core.Meteor;

namespace Core.Operations.EntityRelation.Queries
{
    public class GetEntityRelationAsDropDown : DbQueryAsDropDown<EntityRelation>
    {
        public GetEntityRelationAsDropDown() : base("[Core].[EntityRelation]")
        {
        }
    }
}
