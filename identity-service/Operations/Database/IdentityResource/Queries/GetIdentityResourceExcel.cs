using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Queries
{
    public class GetIdentityResourceExcel : SaanaaDbQueryExcel<IdentityResource>
    {
        public GetIdentityResourceExcel() : base("[Identity].[IdentityResource]")
        {
        }
    }
}