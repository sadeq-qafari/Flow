using Core.Meteor;

namespace Tenant.Operations.Role.Queries
{
    public class GetRoleByIds : DbQueryByIds<Role>
    {
        public GetRoleByIds() : base("[Tenant].[Role]")
        {
        }
    }
}