using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.ApiScope.Queries
{
    public class GetApiScope : SaanaaDbSelectAsync<ApiScope?>
    {
        public GetApiScope() : base("[Identity].[ApiScope]")
        {
        }
    }
}