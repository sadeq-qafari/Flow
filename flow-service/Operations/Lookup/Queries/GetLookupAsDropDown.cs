using Saanaa.Core.Meteor;

namespace Flow.Operations.Lookup.Queries
{
    public class GetLookupAsDropDown : SaanaaDbQueryAsDropDown<Lookup>
    {
        public GetLookupAsDropDown() : base("[Flow].[Lookup]")
        {
        }
    }
}
