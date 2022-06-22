using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Permission.Queries
{
    public class GetPermissionExcel : SaanaaDbQueryExcel<Permission>
    {
        public GetPermissionExcel() : base("[Identity].[Permission]")
        {
        }
    }
}
