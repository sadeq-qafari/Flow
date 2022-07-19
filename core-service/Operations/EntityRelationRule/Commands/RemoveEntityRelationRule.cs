using Core.Meteor;

namespace Core.Operations.EntityRelationRule.Commands
{
    public class RemoveEntityRelationRule : DbDeleteAsync
    {
        public RemoveEntityRelationRule() : base("[Core].[EntityRelationRule]")
        {
        }
    }
}
