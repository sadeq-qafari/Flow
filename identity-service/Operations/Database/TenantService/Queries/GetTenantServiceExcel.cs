using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantService.Queries
{
    public class GetTenantServiceExcel : SaanaaDbQueryExcel<TenantService>
    {
        public GetTenantServiceExcel() : base("[Identity].[TenantService]")
        {
        }
    }
}
