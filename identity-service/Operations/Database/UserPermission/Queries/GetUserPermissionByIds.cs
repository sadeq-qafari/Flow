using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.UserPermission.Queries
{
    public class GetUserPermissionByIds : SaanaaDbQueryByIds<UserPermission>
    {
        public GetUserPermissionByIds() : base("[Identity].[UserPermission]")
        {
        }
    }
}
