using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Queries
{
    public class GetPersistedGrant : SaanaaDbSelectAsync<PersistedGrant?>
    {
        public GetPersistedGrant() : base("[Identity].[PersistedGrant]")
        {
        }
    }
}