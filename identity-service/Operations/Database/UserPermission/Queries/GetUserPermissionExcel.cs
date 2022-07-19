using Core.Meteor;

namespace Identity.Operations.Database.UserPermission.Queries
{
    public class GetUserPermissionExcel : DbQueryExcel<UserPermission>
    {
        public GetUserPermissionExcel() : base("[Identity].[UserPermission]")
        {
        }
    }
}
