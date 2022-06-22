using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Permission.Queries
{
    public class GetPermissionByIds : SaanaaDbQueryByIds<Permission>
    {
        public GetPermissionByIds() : base("[Identity].[Permission]")
        {
        }
    }
}
