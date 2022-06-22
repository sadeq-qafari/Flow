using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Commands
{
    public class IdentityResourceRemove : SaanaaDbDeleteAsync
    {
        public IdentityResourceRemove() : base("[Identity].[IdentityResource]")
        {
        }
    }
}