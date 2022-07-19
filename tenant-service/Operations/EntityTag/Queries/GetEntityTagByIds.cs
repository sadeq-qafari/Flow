using Core.Meteor;

namespace Tenant.Operations.EntityTag.Queries
{
    public class GetEntityTagByIds : DbQueryByIds<EntityTag>
    {
        public GetEntityTagByIds() : base("[Tenant].[EntityTag]")
        {
        }
    }
}