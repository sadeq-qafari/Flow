using Saanaa.Core.Meteor;

namespace Flow.Operations.LookupItem.Queries
{
    public class GetLookupItemAsDropDown : SaanaaDbQueryAsDropDown<LookupItem>
    {
        public GetLookupItemAsDropDown() : base("[Flow].[LookupItem]")
        {
        }
    }
}
