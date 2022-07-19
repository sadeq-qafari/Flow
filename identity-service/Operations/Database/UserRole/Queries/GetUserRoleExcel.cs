using Core.Meteor;

namespace Identity.Operations.Database.UserRole.Queries
{
    public class GetUserRoleExcel : DbQueryExcel<UserRole>
    {
        public GetUserRoleExcel() : base("[Identity].[UserRole]")
        {
        }
    }
}
