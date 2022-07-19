using Core.Meteor;

namespace Core.Operations.EntityRelationRule.Queries
{
    public class GetEntityRelationRule : DbSelectAsync<EntityRelationRule?>
    {
        public GetEntityRelationRule() : base("[Core].[EntityRelationRule]")
        {
        }
    }
}
