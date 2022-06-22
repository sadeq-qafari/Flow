using Saanaa.Core.Meteor;

namespace Flow.Operations.Lookup.Commands
{
    public class LookupRemove : SaanaaDbDeleteAsync
    {
        public LookupRemove() : base("[Flow].[Lookup]")
        {
        }
    }
}