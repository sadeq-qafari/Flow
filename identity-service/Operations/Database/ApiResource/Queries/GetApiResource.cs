using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Queries
{
    public class GetApiResource : SaanaaDbSelectAsync<ApiResource?>
    {
        public GetApiResource() : base("[Identity].[ApiResource]")
        {
        }
    }
}