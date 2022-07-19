using Core.Meteor;

namespace Identity.Operations.Database.UserRole.Queries
{
    public class GetUserRoleByIds : DbQueryByIds<UserRole>
    {
        public GetUserRoleByIds() : base("[Identity].[UserRole]")
        {
        }
    }
}
