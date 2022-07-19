using Core.Meteor;

namespace Core.Operations.EntityRelation.Commands
{
    public class RemoveEntityRelation : DbDeleteAsync
    {
        public RemoveEntityRelation() : base("[Core].[EntityRelation]")
        {
        }
    }
}
