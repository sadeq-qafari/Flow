using Core.Meteor;

namespace Identity.Operations.Database.ApiScope.Queries
{
    public class GetApiScopeAsDropDown : DbQueryAsDropDown<ApiScope>
    {
        public GetApiScopeAsDropDown() : base("[Identity].[ApiScope]")
        {
        }
    }
}
