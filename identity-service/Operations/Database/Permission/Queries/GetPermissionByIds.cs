using Core.Meteor;

namespace Identity.Operations.Database.Permission.Queries
{
    public class GetPermissionByIds : DbQueryByIds<Permission>
    {
        public GetPermissionByIds() : base("[Identity].[Permission]")
        {
        }
    }
}
