using Core.Meteor;

namespace Tenant.Operations.EntityTag.Queries
{
    public class GetEntityTagAsDropDown : DbQueryAsDropDown<EntityTag>
    {
        public GetEntityTagAsDropDown() : base("[Tenant].[EntityTag]")
        {
        }
    }
}
