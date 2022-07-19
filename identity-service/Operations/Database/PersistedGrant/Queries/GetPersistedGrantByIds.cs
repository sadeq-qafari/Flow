using Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Queries
{
    public class GetPersistedGrantByIds : DbQueryByIds<PersistedGrant>
    {
        public GetPersistedGrantByIds() : base("[Identity].[PersistedGrant]")
        {
        }
    }
}