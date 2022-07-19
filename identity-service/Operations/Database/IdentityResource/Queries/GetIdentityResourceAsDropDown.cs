using Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Queries
{
    public class GetIdentityResourceAsDropDown : DbQueryAsDropDown<IdentityResource>
    {
        public GetIdentityResourceAsDropDown() : base("[Identity].[IdentityResource]")
        {
        }
    }
}
