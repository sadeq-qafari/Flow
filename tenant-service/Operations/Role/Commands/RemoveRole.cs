using Core.Meteor;

namespace Tenant.Operations.Role.Commands
{
    public class RemoveRole : DbDeleteAsync
    {
        public RemoveRole() : base("[Tenant].[Role]")
        {
        }
    }
}