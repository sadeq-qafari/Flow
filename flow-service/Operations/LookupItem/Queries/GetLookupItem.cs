using Core.Meteor;

namespace Flow.Operations.LookupItem.Queries
{
    public class GetLookupItem : DbSelectAsync<LookupItem?>
    {
        public GetLookupItem() : base("[Flow].[LookupItem]")
        {
        }
    }
}