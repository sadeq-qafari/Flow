using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantService.Commands
{
    public class TenantServiceRemove : SaanaaDbDeleteAsync
    {
        public TenantServiceRemove() : base("[Identity].[TenantService]")
        {
        }
    }
}
