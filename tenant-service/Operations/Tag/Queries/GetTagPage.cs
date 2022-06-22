using Saanaa.Core.Meteor;
using Tenant.Operations.Tag.Dto;

namespace Tenant.Operations.Tag.Queries
{
    public class GetTagPage : SaanaaDbQueryPage<TagDto>
    {
        public GetTagPage() : base("[Tenant].[Tag]")
        {
        }
        
    }
}