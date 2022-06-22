using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.UserRole.Queries
{
    public class GetUserRoleAsDropDown : SaanaaDbQueryAsDropDown<UserRole>
    {
        public GetUserRoleAsDropDown() : base("[Identity].[UserRole]")
        {
        }
    }
}
