using Saanaa.Core.Meteor;

namespace Tenant.Operations.Tag.Queries
{
    public class GetTagAsDropDown : SaanaaDbQueryAsDropDown<Tag>
    {
        public GetTagAsDropDown() : base("[Tenant].[Tag]")
        {
        }
    }
}
