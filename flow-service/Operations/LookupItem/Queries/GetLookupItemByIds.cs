using Saanaa.Core.Meteor;

namespace Flow.Operations.LookupItem.Queries
{
    public class GetLookupItemByIds : SaanaaDbQueryByIds<LookupItem>
    {
        public GetLookupItemByIds() : base("[Flow].[LookupItem]")
        {
        }
    }
}