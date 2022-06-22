using Saanaa.Core.Meteor;

namespace Tenant.Operations.Tag.Queries
{
    public class GetTagExcel : SaanaaDbQueryExcel<Tag>
    {
        public GetTagExcel() : base("[Tenant].[Tag]")
        {
        }
    }
}