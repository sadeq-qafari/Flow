using Saanaa.Core.Meteor;

namespace Flow.Operations.FormPermission.Queries
{
    public class GetFormPermissionByIds : SaanaaDbQueryByIds<FormPermission>
    {
        public GetFormPermissionByIds() : base("[Flow].[FormPermission]")
        {
        }
    }
}