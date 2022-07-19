using Core.Meteor;

namespace Tenant.Operations.Department.Queries
{
    public class GetDepartmentAsDropDown : DbQueryAsDropDown<Department>
    {
        public GetDepartmentAsDropDown() : base("[Tenant].[Department]")
        {
        }
    }
}
