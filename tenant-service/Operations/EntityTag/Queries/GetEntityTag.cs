using Core.Meteor;

namespace Tenant.Operations.EntityTag.Queries
{
    public class GetEntityTag : DbSelectAsync<EntityTag?>
    {
        public GetEntityTag() : base("[Tenant].[EntityTag]")
        {
        }
    }
}