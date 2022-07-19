using Core.Meteor;

namespace Identity.Operations.Database.TenantService.Commands
{
    public class TenantServiceRemove : DbDeleteAsync
    {
        public TenantServiceRemove() : base("[Identity].[TenantService]")
        {
        }
    }
}
