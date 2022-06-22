using Identity.Operations.Database.PersistedGrant.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Commands
{
    public class PersistedGrantUpdate : SaanaaDbUpdateAsync<PersistedGrantUpdateInDto>
    {
        public PersistedGrantUpdate() : base("[Identity].[PersistedGrant]",
            @"")
        {
        }
    }
}