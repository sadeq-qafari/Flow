using Core.Meteor;

namespace Tenant.Operations.Tag.Queries
{
    public class GetTag : DbSelectAsync<Tag?>
    {
        public GetTag() : base("[Tenant].[Tag]")
        {
        }
    }
}