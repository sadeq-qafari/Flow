using Saanaa.Core.Meteor;

namespace Flow.Operations.LookupItem.Commands
{
    public class LookupItemRemove : SaanaaDbDeleteAsync
    {
        public LookupItemRemove() : base("[Flow].[LookupItem]")
        {
        }
    }
}