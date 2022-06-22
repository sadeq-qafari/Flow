using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantUrl.Commands
{
    public class TenantUrlRemove : SaanaaDbDeleteAsync
    {
        public TenantUrlRemove() : base("[Identity].[TenantUrl]")
        {
        }
    }
}