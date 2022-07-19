using Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Queries
{
    public class GetPersistedGrantAsDropDown : DbQueryAsDropDown<PersistedGrant>
    {
        public GetPersistedGrantAsDropDown() : base("[Identity].[PersistedGrant]")
        {
        }
    }
}
