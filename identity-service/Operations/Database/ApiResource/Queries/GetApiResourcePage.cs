using Identity.Operations.Database.ApiResource.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Queries
{
    public class GetApiResourcePage : DbQueryPage<ApiResourceDto>
    {
        public GetApiResourcePage() : base("[Identity].[ApiResource]")
        {
        }
        
    }
}