using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantService.Queries
{
    public class GetTenantServiceAsDropDown : SaanaaDbQueryAsDropDown<TenantService>
    {
        public GetTenantServiceAsDropDown() : base("[Identity].[TenantService]")
        {
        }
    }
}
