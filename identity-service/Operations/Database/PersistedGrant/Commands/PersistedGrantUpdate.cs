using Identity.Operations.Database.PersistedGrant.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Commands
{
    public class PersistedGrantUpdate : DbUpdateAsync<PersistedGrantUpdateInDto>
    {
        public PersistedGrantUpdate() : base("[Identity].[PersistedGrant]",
            @"")
        {
        }
    }
}