using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantService.Queries
{
    public class GetTenantServiceByIds : SaanaaDbQueryByIds<TenantService>
    {
        public GetTenantServiceByIds() : base("[Identity].[TenantService]")
        {
        }
    }
}
