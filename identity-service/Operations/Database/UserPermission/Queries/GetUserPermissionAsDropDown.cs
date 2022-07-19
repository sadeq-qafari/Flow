using Core.Meteor;

namespace Identity.Operations.Database.UserPermission.Queries
{
    public class GetUserPermissionAsDropDown : DbQueryAsDropDown<UserPermission>
    {
        public GetUserPermissionAsDropDown() : base("[Identity].[UserPermission]")
        {
        }
    }
}
