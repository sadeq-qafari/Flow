using Core.Meteor;
using Tenant.Operations.Department.Dto;

namespace Tenant.Operations.Department.Commands
{
    public class AddDepartment : DbInsertAsync<AddDepartmentInDto>
    {
        public AddDepartment() : base("[Tenant].[Department]",
            "[ParentId], [Title]",
            "@ParentId, @Title")
        {
        }
    }
}

