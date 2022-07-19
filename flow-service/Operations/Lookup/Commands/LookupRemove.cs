using Core.Meteor;

namespace Flow.Operations.Lookup.Commands
{
    public class LookupRemove : DbDeleteAsync
    {
        public LookupRemove() : base("[Flow].[Lookup]")
        {
        }
    }
}