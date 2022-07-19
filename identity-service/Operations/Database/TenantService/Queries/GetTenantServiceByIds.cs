using Core.Meteor;

namespace Identity.Operations.Database.TenantService.Queries
{
    public class GetTenantServiceByIds : DbQueryByIds<TenantService>
    {
        public GetTenantServiceByIds() : base("[Identity].[TenantService]")
        {
        }
    }
}
