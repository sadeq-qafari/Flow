using Core.Meteor;

namespace Flow.Operations.Lookup.Queries
{
    public class GetLookup : DbSelectAsync<Lookup?>
    {
        public GetLookup() : base("[Flow].[Lookup]")
        {
        }
    }
}