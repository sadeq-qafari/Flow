using Core.Meteor;

namespace Tenant.Operations.Organization.Commands
{
    public class RemoveOrganization : DbDeleteAsync
    {
        public RemoveOrganization() : base("[Tenant].[Organization]")
        {
        }
    }
}