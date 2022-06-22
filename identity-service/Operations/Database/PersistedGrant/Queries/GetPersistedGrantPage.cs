using Identity.Operations.Database.PersistedGrant.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Queries
{
    public class GetPersistedGrantPage : SaanaaDbQueryPage<PersistedGrantDto>
    {
        public GetPersistedGrantPage() : base("[Identity].[PersistedGrant]")
        {
        }
        
    }
}