using Core.Meteor;

namespace Flow.Operations.LookupItem.Commands
{
    public class LookupItemRemove : DbDeleteAsync
    {
        public LookupItemRemove() : base("[Flow].[LookupItem]")
        {
        }
    }
}