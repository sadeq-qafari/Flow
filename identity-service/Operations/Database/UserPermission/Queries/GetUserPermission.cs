using Core.Meteor;

namespace Identity.Operations.Database.UserPermission.Queries
{
    public class GetUserPermission : DbSelectAsync<UserPermission?>
    {
        public GetUserPermission() : base("[Identity].[UserPermission]")
        {
        }
    }
}
