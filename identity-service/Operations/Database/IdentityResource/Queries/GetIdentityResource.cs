using Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Queries
{
    public class GetIdentityResource : DbSelectAsync<IdentityResource?>
    {
        public GetIdentityResource() : base("[Identity].[IdentityResource]")
        {
        }
    }
}