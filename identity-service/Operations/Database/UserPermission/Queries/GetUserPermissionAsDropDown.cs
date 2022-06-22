using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.UserPermission.Queries
{
    public class GetUserPermissionAsDropDown : SaanaaDbQueryAsDropDown<UserPermission>
    {
        public GetUserPermissionAsDropDown() : base("[Identity].[UserPermission]")
        {
        }
    }
}
