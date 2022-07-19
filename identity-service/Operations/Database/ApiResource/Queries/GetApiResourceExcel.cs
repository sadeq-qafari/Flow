using Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Queries
{
    public class GetApiResourceExcel : DbQueryExcel<ApiResource>
    {
        public GetApiResourceExcel() : base("[Identity].[ApiResource]")
        {
        }
    }
}