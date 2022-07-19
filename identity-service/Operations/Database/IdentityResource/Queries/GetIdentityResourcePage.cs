using Identity.Operations.Database.IdentityResource.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Queries
{
    public class GetIdentityResourcePage : DbQueryPage<IdentityResourceDto>
    {
        public GetIdentityResourcePage() : base("[Identity].[IdentityResource]")
        {
        }
        
    }
}