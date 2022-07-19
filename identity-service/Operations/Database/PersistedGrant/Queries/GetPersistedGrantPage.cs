using Identity.Operations.Database.PersistedGrant.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Queries
{
    public class GetPersistedGrantPage : DbQueryPage<PersistedGrantDto>
    {
        public GetPersistedGrantPage() : base("[Identity].[PersistedGrant]")
        {
        }
        
    }
}