using Saanaa.Core.Meteor;
using Tenant.Operations.Department.Dto;

namespace Tenant.Operations.Department.Commands
{
    public class UpdateDepartment : SaanaaDbUpdateAsync<UpdateDepartmentInDto>
    {
        public UpdateDepartment() : base("[Tenant].[Department]",
            "[ParentId]=@ParentId, [Title]=@Title")
        {
        }
    }
}