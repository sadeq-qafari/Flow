using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Queries
{
    public class GetApiResourceAsDropDown : SaanaaDbQueryAsDropDown<ApiResource>
    {
        public GetApiResourceAsDropDown() : base("[Identity].[ApiResource]")
        {
        }
    }
}
