using Core.Meteor;

namespace Identity.Operations.Database.TenantRegisterRequest.Commands
{
    public class TenantRegisterRequestRemove : DbDeleteAsync
    {
        public TenantRegisterRequestRemove() : base("[Identity].[TenantRegisterRequest]")
        {
        }
    }
}