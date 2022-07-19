using Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Queries
{
    public class GetApiResourceAsDropDown : DbQueryAsDropDown<ApiResource>
    {
        public GetApiResourceAsDropDown() : base("[Identity].[ApiResource]")
        {
        }
    }
}
