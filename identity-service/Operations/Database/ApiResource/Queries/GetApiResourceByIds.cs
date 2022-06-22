using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Queries
{
    public class GetApiResourceByIds : SaanaaDbQueryByIds<ApiResource>
    {
        public GetApiResourceByIds() : base("[Identity].[ApiResource]")
        {
        }
    }
}