using Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Queries
{
    public class GetPersistedGrant : DbSelectAsync<PersistedGrant?>
    {
        public GetPersistedGrant() : base("[Identity].[PersistedGrant]")
        {
        }
    }
}