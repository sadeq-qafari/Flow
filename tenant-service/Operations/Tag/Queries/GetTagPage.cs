using Core.Meteor;
using Tenant.Operations.Tag.Dto;

namespace Tenant.Operations.Tag.Queries
{
    public class GetTagPage : DbQueryPage<TagDto>
    {
        public GetTagPage() : base("[Tenant].[Tag]")
        {
        }
        
    }
}