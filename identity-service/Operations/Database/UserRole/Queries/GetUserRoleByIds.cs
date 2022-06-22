using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.UserRole.Queries
{
    public class GetUserRoleByIds : SaanaaDbQueryByIds<UserRole>
    {
        public GetUserRoleByIds() : base("[Identity].[UserRole]")
        {
        }
    }
}
