using Core.Meteor;

namespace Tenant.Operations.Tag.Queries
{
    public class GetTagByIds : DbQueryByIds<Tag>
    {
        public GetTagByIds() : base("[Tenant].[Tag]")
        {
        }
    }
}