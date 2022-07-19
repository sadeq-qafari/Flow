using Core.Meteor;
using Tenant.Operations.Role.Dto;

namespace Tenant.Operations.Role.Commands
{
    public class UpdateRole : DbUpdateAsync<UpdateRoleInDto>
    {
        public UpdateRole() : base("[Tenant].[Role]",
            "[Title]=@Title, [DepartmentId]=@DepartmentId, [ParentId]=@ParentId")
        {
        }
    }
}