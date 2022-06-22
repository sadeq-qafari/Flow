using Saanaa.Core.Meteor;

namespace Tenant.Operations.EntityTag.Queries
{
    public class GetEntityTag : SaanaaDbSelectAsync<EntityTag?>
    {
        public GetEntityTag() : base("[Tenant].[EntityTag]")
        {
        }
    }
}