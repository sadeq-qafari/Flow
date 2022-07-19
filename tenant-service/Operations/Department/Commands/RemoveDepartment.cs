using Core.Meteor;

namespace Tenant.Operations.Department.Commands
{
    public class RemoveDepartment : DbDeleteAsync
    {
        public RemoveDepartment() : base("[Tenant].[Department]")
        {
        }
    }
}