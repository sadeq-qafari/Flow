using Core.Meteor;

namespace Identity.Operations.Database.TenantService.Queries
{
    public class GetTenantService : DbSelectAsync<TenantService?>
    {
        public GetTenantService() : base("[Identity].[TenantService]")
        {
        }
    }
}
