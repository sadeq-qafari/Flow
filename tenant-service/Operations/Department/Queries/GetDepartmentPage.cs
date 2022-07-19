using Core.Meteor;
using Tenant.Operations.Department.Dto;

namespace Tenant.Operations.Department.Queries
{
    public class GetDepartmentPage : DbQueryPage<DepartmentDto>
    {
        public GetDepartmentPage() : base("[Tenant].[Department]")
        {
        }
        
    }
}