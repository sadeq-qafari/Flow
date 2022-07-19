using Core.Meteor;

namespace Tenant.Operations.Role.Queries
{
    public class GetRoleExcel : DbQueryExcel<Role>
    {
        public GetRoleExcel() : base("[Tenant].[Role]")
        {
        }
    }
}