using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Queries
{
    public class GetApiResourceExcel : SaanaaDbQueryExcel<ApiResource>
    {
        public GetApiResourceExcel() : base("[Identity].[ApiResource]")
        {
        }
    }
}