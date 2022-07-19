using Core.Meteor;

namespace Identity.Operations.Database.Permission.Queries
{
    public class GetPermissionExcel : DbQueryExcel<Permission>
    {
        public GetPermissionExcel() : base("[Identity].[Permission]")
        {
        }
    }
}
