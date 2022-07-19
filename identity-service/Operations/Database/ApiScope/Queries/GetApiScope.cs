using Core.Meteor;

namespace Identity.Operations.Database.ApiScope.Queries
{
    public class GetApiScope : DbSelectAsync<ApiScope?>
    {
        public GetApiScope() : base("[Identity].[ApiScope]")
        {
        }
    }
}