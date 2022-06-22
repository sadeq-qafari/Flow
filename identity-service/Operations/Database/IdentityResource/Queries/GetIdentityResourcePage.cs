using Identity.Operations.Database.IdentityResource.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Queries
{
    public class GetIdentityResourcePage : SaanaaDbQueryPage<IdentityResourceDto>
    {
        public GetIdentityResourcePage() : base("[Identity].[IdentityResource]")
        {
        }
        
    }
}