using Core.Meteor;

namespace Flow.Operations.Lookup.Queries
{
    public class GetLookupAsDropDown : DbQueryAsDropDown<Lookup>
    {
        public GetLookupAsDropDown() : base("[Flow].[Lookup]")
        {
        }
    }
}
