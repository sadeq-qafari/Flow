using Saanaa.Core.Meteor;

namespace Tenant.Operations.Tag.Queries
{
    public class GetTag : SaanaaDbSelectAsync<Tag?>
    {
        public GetTag() : base("[Tenant].[Tag]")
        {
        }
    }
}