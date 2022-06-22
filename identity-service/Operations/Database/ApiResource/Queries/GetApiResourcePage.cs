using Identity.Operations.Database.ApiResource.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Queries
{
    public class GetApiResourcePage : SaanaaDbQueryPage<ApiResourceDto>
    {
        public GetApiResourcePage() : base("[Identity].[ApiResource]")
        {
        }
        
    }
}