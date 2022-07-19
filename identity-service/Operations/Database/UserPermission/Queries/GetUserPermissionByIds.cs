using Core.Meteor;

namespace Identity.Operations.Database.UserPermission.Queries
{
    public class GetUserPermissionByIds : DbQueryByIds<UserPermission>
    {
        public GetUserPermissionByIds() : base("[Identity].[UserPermission]")
        {
        }
    }
}
