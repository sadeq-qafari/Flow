using Saanaa.Core.Meteor;

namespace Tenant.Operations.Tag.Queries
{
    public class GetTagByIds : SaanaaDbQueryByIds<Tag>
    {
        public GetTagByIds() : base("[Tenant].[Tag]")
        {
        }
    }
}