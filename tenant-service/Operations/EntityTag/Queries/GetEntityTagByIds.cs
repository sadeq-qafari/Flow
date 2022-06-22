using Saanaa.Core.Meteor;

namespace Tenant.Operations.EntityTag.Queries
{
    public class GetEntityTagByIds : SaanaaDbQueryByIds<EntityTag>
    {
        public GetEntityTagByIds() : base("[Tenant].[EntityTag]")
        {
        }
    }
}