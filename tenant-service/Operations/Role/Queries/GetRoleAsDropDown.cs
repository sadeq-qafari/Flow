using Core.Meteor;

namespace Tenant.Operations.Role.Queries
{
    public class GetRoleAsDropDown : DbQueryAsDropDown<Role>
    {
        public GetRoleAsDropDown() : base("[Tenant].[Role]")
        {
        }
    }
}
