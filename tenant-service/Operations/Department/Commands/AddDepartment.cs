using Saanaa.Core.Meteor;
using Tenant.Operations.Department.Dto;

namespace Tenant.Operations.Department.Commands
{
    public class AddDepartment : SaanaaDbInsertAsync<AddDepartmentInDto>
    {
        public AddDepartment() : base("[Tenant].[Department]",
            "[ParentId], [Title]",
            "@ParentId, @Title")
        {
        }
    }
}

