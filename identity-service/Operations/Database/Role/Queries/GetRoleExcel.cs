using Core.Meteor;

namespace Identity.Operations.Database.Role.Queries
{
    public class GetRoleExcel : DbQueryExcel<Role>
    {
        public GetRoleExcel() : base("[Identity].[Role]")
        {
        }
    }
}
