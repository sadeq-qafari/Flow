using Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Queries
{
    public class GetApiResourceByIds : DbQueryByIds<ApiResource>
    {
        public GetApiResourceByIds() : base("[Identity].[ApiResource]")
        {
        }
    }
}