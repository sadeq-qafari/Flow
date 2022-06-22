using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantUser.Commands
{
    public class TenantUserRemove : SaanaaDbDeleteAsync
    {
        public TenantUserRemove() : base("[Identity].[TenantUser]")
        {
        }
    }
}
