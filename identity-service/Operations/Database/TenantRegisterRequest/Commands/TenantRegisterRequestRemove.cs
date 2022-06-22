using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantRegisterRequest.Commands
{
    public class TenantRegisterRequestRemove : SaanaaDbDeleteAsync
    {
        public TenantRegisterRequestRemove() : base("[Identity].[TenantRegisterRequest]")
        {
        }
    }
}