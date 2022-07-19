using Core.Meteor;

namespace Tenant.Operations.Department.Queries
{
    public class GetDepartmentByIds : DbQueryByIds<Department>
    {
        public GetDepartmentByIds() : base("[Tenant].[Department]")
        {
        }
    }
}