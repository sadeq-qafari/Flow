using Identity.Operations.Database.Tenant.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.Tenant.Queries
{
    public class GetTenantPage : DbQueryPage<TenantDto>
    {
        public GetTenantPage() : base("[Identity].[Tenant]")
        {
        }
        
    }
}
