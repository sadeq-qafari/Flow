using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Tenant.Commands
{
    public class TenantRemove : SaanaaDbDeleteAsync
    {
        public TenantRemove() : base("[Identity].[Tenant]")
        {
        }
    }
}
