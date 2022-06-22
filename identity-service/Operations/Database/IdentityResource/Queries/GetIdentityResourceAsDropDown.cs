using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Queries
{
    public class GetIdentityResourceAsDropDown : SaanaaDbQueryAsDropDown<IdentityResource>
    {
        public GetIdentityResourceAsDropDown() : base("[Identity].[IdentityResource]")
        {
        }
    }
}
