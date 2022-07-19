using Core.Meteor;

namespace Core.Operations.Version.Commands
{
    public class RemoveVersion : DbDeleteAsync
    {
        public RemoveVersion() : base("[Core].[Version]")
        {
        }
    }
}
