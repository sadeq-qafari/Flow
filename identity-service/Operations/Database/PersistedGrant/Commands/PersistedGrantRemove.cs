using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Commands
{
    public class PersistedGrantRemove : SaanaaDbDeleteAsync
    {
        public PersistedGrantRemove() : base("[Identity].[PersistedGrant]")
        {
        }
    }
}