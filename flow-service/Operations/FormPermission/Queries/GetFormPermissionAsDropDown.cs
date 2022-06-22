using Saanaa.Core.Meteor;

namespace Flow.Operations.FormPermission.Queries
{
    public class GetFormPermissionAsDropDown : SaanaaDbQueryAsDropDown<FormPermission>
    {
        public GetFormPermissionAsDropDown() : base("[Flow].[FormPermission]")
        {
        }
    }
}
