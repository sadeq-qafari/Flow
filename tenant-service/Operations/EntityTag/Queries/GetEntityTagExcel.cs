using Core.Meteor;

namespace Tenant.Operations.EntityTag.Queries
{
    public class GetEntityTagExcel : DbQueryExcel<EntityTag>
    {
        public GetEntityTagExcel() : base("[Tenant].[EntityTag]")
        {
        }
    }
}