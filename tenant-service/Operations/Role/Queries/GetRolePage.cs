using Core.Meteor;
using Tenant.Operations.Role.Dto;

namespace Tenant.Operations.Role.Queries
{
    public class GetRolePage : DbQueryPage<RoleDto>
    {
        public GetRolePage() : base("[Tenant].[Role]")
        {
        }
        
    }
}