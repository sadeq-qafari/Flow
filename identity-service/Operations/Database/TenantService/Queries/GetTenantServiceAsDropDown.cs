using Core.Meteor;

namespace Identity.Operations.Database.TenantService.Queries
{
    public class GetTenantServiceAsDropDown : DbQueryAsDropDown<TenantService>
    {
        public GetTenantServiceAsDropDown() : base("[Identity].[TenantService]")
        {
        }
    }
}
