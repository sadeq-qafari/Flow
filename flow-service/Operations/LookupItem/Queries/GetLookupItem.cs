using Saanaa.Core.Meteor;

namespace Flow.Operations.LookupItem.Queries
{
    public class GetLookupItem : SaanaaDbSelectAsync<LookupItem?>
    {
        public GetLookupItem() : base("[Flow].[LookupItem]")
        {
        }
    }
}