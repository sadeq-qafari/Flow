using Core.Meteor;
using Tenant.Operations.Role.Dto;

namespace Tenant.Operations.Role.Commands
{
    public class AddRole : DbInsertAsync<AddRoleInDto>
    {
        public AddRole() : base("[Tenant].[Role]",
            "[Title], [DepartmentId], [ParentId]",
            "@Title, @DepartmentId, @ParentId")
        {
        }
    }
}

