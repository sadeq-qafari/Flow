using Core.Meteor;

namespace Flow.Operations.Lookup.Queries
{
    public class GetLookupByIds : DbQueryByIds<Lookup>
    {
        public GetLookupByIds() : base("[Flow].[Lookup]")
        {
        }
    }
}