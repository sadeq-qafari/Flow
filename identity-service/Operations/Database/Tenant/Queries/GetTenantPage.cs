using Identity.Operations.Database.Tenant.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Tenant.Queries
{
    public class GetTenantPage : SaanaaDbQueryPage<TenantDto>
    {
        public GetTenantPage() : base("[Identity].[Tenant]")
        {
        }
        
    }
}
