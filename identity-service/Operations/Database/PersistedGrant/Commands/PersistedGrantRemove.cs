using Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Commands
{
    public class PersistedGrantRemove : DbDeleteAsync
    {
        public PersistedGrantRemove() : base("[Identity].[PersistedGrant]")
        {
        }
    }
}