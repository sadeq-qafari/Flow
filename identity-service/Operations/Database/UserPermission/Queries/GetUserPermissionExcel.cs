using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.UserPermission.Queries
{
    public class GetUserPermissionExcel : SaanaaDbQueryExcel<UserPermission>
    {
        public GetUserPermissionExcel() : base("[Identity].[UserPermission]")
        {
        }
    }
}
