using Core.Meteor;

namespace Identity.Operations.Database.ApiScope.Queries
{
    public class GetApiScopeByIds : DbQueryByIds<ApiScope>
    {
        public GetApiScopeByIds() : base("[Identity].[ApiScope]")
        {
        }
    }
}