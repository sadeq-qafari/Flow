using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Queries
{
    public class GetIdentityResource : SaanaaDbSelectAsync<IdentityResource?>
    {
        public GetIdentityResource() : base("[Identity].[IdentityResource]")
        {
        }
    }
}