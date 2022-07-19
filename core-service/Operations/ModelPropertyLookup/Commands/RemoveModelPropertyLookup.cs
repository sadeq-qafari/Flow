using Core.Meteor;

namespace Core.Operations.ModelPropertyLookup.Commands
{
    public class RemoveModelPropertyLookup : DbDeleteAsync
    {
        public RemoveModelPropertyLookup() : base("[Core].[ModelPropertyLookup]")
        {
        }
    }
}
