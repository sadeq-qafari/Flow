using Core.Meteor;

namespace Identity.Operations.Database.TenantUser.Commands
{
    public class TenantUserRemove : DbDeleteAsync
    {
        public TenantUserRemove() : base("[Identity].[TenantUser]")
        {
        }
    }
}
