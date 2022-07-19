using Core.Meteor;

namespace Identity.Operations.Database.UserRole.Queries
{
    public class GetUserRoleAsDropDown : DbQueryAsDropDown<UserRole>
    {
        public GetUserRoleAsDropDown() : base("[Identity].[UserRole]")
        {
        }
    }
}
