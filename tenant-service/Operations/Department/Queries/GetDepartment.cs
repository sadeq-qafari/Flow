using Core.Meteor;

namespace Tenant.Operations.Department.Queries
{
    public class GetDepartment : DbSelectAsync<Department?>
    {
        public GetDepartment() : base("[Tenant].[Department]")
        {
        }
    }
}