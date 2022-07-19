using Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Commands
{
    public class IdentityResourceRemove : DbDeleteAsync
    {
        public IdentityResourceRemove() : base("[Identity].[IdentityResource]")
        {
        }
    }
}