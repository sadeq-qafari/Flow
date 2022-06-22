using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.ApiScope.Queries
{
    public class GetApiScopeAsDropDown : SaanaaDbQueryAsDropDown<ApiScope>
    {
        public GetApiScopeAsDropDown() : base("[Identity].[ApiScope]")
        {
        }
    }
}
