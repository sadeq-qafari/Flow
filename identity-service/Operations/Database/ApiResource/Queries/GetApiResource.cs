using Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Queries
{
    public class GetApiResource : DbSelectAsync<ApiResource?>
    {
        public GetApiResource() : base("[Identity].[ApiResource]")
        {
        }
    }
}