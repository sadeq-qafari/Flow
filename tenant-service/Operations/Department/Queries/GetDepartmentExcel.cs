using Core.Meteor;

namespace Tenant.Operations.Department.Queries
{
    public class GetDepartmentExcel : DbQueryExcel<Department>
    {
        public GetDepartmentExcel() : base("[Tenant].[Department]")
        {
        }
    }
}