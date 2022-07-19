using Core.Meteor;

namespace Identity.Operations.Database.UserRole.Queries
{
    public class GetUserRole : DbSelectAsync<UserRole?>
    {
        public GetUserRole() : base("[Identity].[UserRole]")
        {
        }
    }
}
