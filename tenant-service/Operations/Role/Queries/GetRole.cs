using Core.Meteor;

namespace Tenant.Operations.Role.Queries
{
    public class GetRole : DbSelectAsync<Role?>
    {
        public GetRole() : base("[Tenant].[Role]")
        {
        }
    }
}