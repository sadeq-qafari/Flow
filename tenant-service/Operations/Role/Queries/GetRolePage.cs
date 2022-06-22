using Saanaa.Core.Meteor;
using Tenant.Operations.Role.Dto;

namespace Tenant.Operations.Role.Queries
{
    public class GetRolePage : SaanaaDbQueryPage<RoleDto>
    {
        public GetRolePage() : base("[Tenant].[Role]")
        {
        }
        
    }
}