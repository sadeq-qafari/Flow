using Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Queries
{
    public class GetIdentityResourceExcel : DbQueryExcel<IdentityResource>
    {
        public GetIdentityResourceExcel() : base("[Identity].[IdentityResource]")
        {
        }
    }
}