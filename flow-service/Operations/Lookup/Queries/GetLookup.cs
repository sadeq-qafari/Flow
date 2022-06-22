using Saanaa.Core.Meteor;

namespace Flow.Operations.Lookup.Queries
{
    public class GetLookup : SaanaaDbSelectAsync<Lookup?>
    {
        public GetLookup() : base("[Flow].[Lookup]")
        {
        }
    }
}