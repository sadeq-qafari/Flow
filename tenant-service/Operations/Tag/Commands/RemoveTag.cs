using Core.Meteor;

namespace Tenant.Operations.Tag.Commands
{
    public class RemoveTag : DbDeleteAsync
    {
        public RemoveTag() : base("[Tenant].[Tag]")
        {
        }
    }
}