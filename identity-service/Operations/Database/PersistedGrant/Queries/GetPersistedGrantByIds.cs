using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Queries
{
    public class GetPersistedGrantByIds : SaanaaDbQueryByIds<PersistedGrant>
    {
        public GetPersistedGrantByIds() : base("[Identity].[PersistedGrant]")
        {
        }
    }
}