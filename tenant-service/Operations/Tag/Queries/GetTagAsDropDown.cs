using Core.Meteor;

namespace Tenant.Operations.Tag.Queries
{
    public class GetTagAsDropDown : DbQueryAsDropDown<Tag>
    {
        public GetTagAsDropDown() : base("[Tenant].[Tag]")
        {
        }
    }
}
