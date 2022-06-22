using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.ApiScope.Queries
{
    public class GetApiScopeByIds : SaanaaDbQueryByIds<ApiScope>
    {
        public GetApiScopeByIds() : base("[Identity].[ApiScope]")
        {
        }
    }
}