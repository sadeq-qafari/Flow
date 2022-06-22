using Saanaa.Core.Meteor;

namespace Tenant.Operations.Organization.Commands
{
    public class RemoveOrganization : SaanaaDbDeleteAsync
    {
        public RemoveOrganization() : base("[Tenant].[Organization]")
        {
        }
    }
}