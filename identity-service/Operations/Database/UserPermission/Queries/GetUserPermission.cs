using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.UserPermission.Queries
{
    public class GetUserPermission : SaanaaDbSelectAsync<UserPermission?>
    {
        public GetUserPermission() : base("[Identity].[UserPermission]")
        {
        }
    }
}
