using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantService.Queries
{
    public class GetTenantService : SaanaaDbSelectAsync<TenantService?>
    {
        public GetTenantService() : base("[Identity].[TenantService]")
        {
        }
    }
}
