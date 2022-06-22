using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.ApiScope.Queries
{
    public class GetApiScopeExcel : SaanaaDbQueryExcel<ApiScope>
    {
        public GetApiScopeExcel() : base("[Identity].[ApiScope]")
        {
        }
    }
}