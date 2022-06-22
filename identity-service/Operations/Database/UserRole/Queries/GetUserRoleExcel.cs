using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.UserRole.Queries
{
    public class GetUserRoleExcel : SaanaaDbQueryExcel<UserRole>
    {
        public GetUserRoleExcel() : base("[Identity].[UserRole]")
        {
        }
    }
}
