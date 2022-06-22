using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Queries
{
    public class GetPersistedGrantAsDropDown : SaanaaDbQueryAsDropDown<PersistedGrant>
    {
        public GetPersistedGrantAsDropDown() : base("[Identity].[PersistedGrant]")
        {
        }
    }
}
