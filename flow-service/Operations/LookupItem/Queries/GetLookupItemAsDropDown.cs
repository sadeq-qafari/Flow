using Core.Meteor;

namespace Flow.Operations.LookupItem.Queries
{
    public class GetLookupItemAsDropDown : DbQueryAsDropDown<LookupItem>
    {
        public GetLookupItemAsDropDown() : base("[Flow].[LookupItem]")
        {
        }
    }
}
