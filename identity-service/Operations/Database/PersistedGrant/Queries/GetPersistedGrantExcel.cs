using Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Queries
{
    public class GetPersistedGrantExcel : DbQueryExcel<PersistedGrant>
    {
        public GetPersistedGrantExcel() : base("[Identity].[PersistedGrant]")
        {
        }
    }
}