using Core.Meteor;

namespace Flow.Operations.LookupItem.Queries
{
    public class GetLookupItemByIds : DbQueryByIds<LookupItem>
    {
        public GetLookupItemByIds() : base("[Flow].[LookupItem]")
        {
        }
    }
}