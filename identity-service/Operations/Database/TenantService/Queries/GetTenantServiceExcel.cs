using Core.Meteor;

namespace Identity.Operations.Database.TenantService.Queries
{
    public class GetTenantServiceExcel : DbQueryExcel<TenantService>
    {
        public GetTenantServiceExcel() : base("[Identity].[TenantService]")
        {
        }
    }
}
