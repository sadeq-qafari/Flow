using Saanaa.Core.Meteor;

namespace Tenant.Operations.EntityTag.Commands
{
    public class EntityTagRemove : SaanaaDbDeleteAsync
    {
        public EntityTagRemove() : base("[Tenant].[EntityTag]")
        {
        }
    }
}