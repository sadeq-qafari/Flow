using Core.Meteor;

namespace Identity.Operations.Database.ApiScope.Queries
{
    public class GetApiScopeExcel : DbQueryExcel<ApiScope>
    {
        public GetApiScopeExcel() : base("[Identity].[ApiScope]")
        {
        }
    }
}