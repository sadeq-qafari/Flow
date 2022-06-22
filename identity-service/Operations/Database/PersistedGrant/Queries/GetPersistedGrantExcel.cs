using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Queries
{
    public class GetPersistedGrantExcel : SaanaaDbQueryExcel<PersistedGrant>
    {
        public GetPersistedGrantExcel() : base("[Identity].[PersistedGrant]")
        {
        }
    }
}