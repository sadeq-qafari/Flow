using Saanaa.Core.Meteor;

namespace Flow.Operations.Lookup.Queries
{
    public class GetLookupByIds : SaanaaDbQueryByIds<Lookup>
    {
        public GetLookupByIds() : base("[Flow].[Lookup]")
        {
        }
    }
}