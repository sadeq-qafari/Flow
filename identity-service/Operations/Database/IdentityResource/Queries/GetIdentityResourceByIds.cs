using Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Queries
{
    public class GetIdentityResourceByIds : DbQueryByIds<IdentityResource>
    {
        public GetIdentityResourceByIds() : base("[Identity].[IdentityResource]")
        {
        }
    }
}