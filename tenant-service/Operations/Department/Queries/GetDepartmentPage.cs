using Saanaa.Core.Meteor;
using Tenant.Operations.Department.Dto;

namespace Tenant.Operations.Department.Queries
{
    public class GetDepartmentPage : SaanaaDbQueryPage<DepartmentDto>
    {
        public GetDepartmentPage() : base("[Tenant].[Department]")
        {
        }
        
    }
}