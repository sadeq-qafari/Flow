using Core.Meteor;

namespace Tenant.Operations.EntityTag.Commands
{
    public class EntityTagRemove : DbDeleteAsync
    {
        public EntityTagRemove() : base("[Tenant].[EntityTag]")
        {
        }
    }
}