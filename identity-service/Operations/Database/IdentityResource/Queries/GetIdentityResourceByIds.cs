using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Queries
{
    public class GetIdentityResourceByIds : SaanaaDbQueryByIds<IdentityResource>
    {
        public GetIdentityResourceByIds() : base("[Identity].[IdentityResource]")
        {
        }
    }
}