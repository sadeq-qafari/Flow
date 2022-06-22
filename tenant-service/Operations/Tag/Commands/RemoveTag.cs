using Saanaa.Core.Meteor;

namespace Tenant.Operations.Tag.Commands
{
    public class RemoveTag : SaanaaDbDeleteAsync
    {
        public RemoveTag() : base("[Tenant].[Tag]")
        {
        }
    }
}