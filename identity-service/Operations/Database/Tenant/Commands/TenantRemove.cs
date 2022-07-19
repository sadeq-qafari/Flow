using Core.Meteor;

namespace Identity.Operations.Database.Tenant.Commands
{
    public class TenantRemove : DbDeleteAsync
    {
        public TenantRemove() : base("[Identity].[Tenant]")
        {
        }
    }
}
