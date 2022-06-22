using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.UserRole.Queries
{
    public class GetUserRole : SaanaaDbSelectAsync<UserRole?>
    {
        public GetUserRole() : base("[Identity].[UserRole]")
        {
        }
    }
}
