using Saanaa.Core.Meteor;

namespace Tenant.Operations.Role.Commands
{
    public class RemoveRole : SaanaaDbDeleteAsync
    {
        public RemoveRole() : base("[Tenant].[Role]")
        {
        }
    }
}