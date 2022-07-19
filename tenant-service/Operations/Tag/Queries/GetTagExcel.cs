using Core.Meteor;

namespace Tenant.Operations.Tag.Queries
{
    public class GetTagExcel : DbQueryExcel<Tag>
    {
        public GetTagExcel() : base("[Tenant].[Tag]")
        {
        }
    }
}