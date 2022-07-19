using Core.Meteor;

namespace Flow.Operations.FormPermission.Queries
{
    public class GetFormPermissionAsDropDown : DbQueryAsDropDown<FormPermission>
    {
        public GetFormPermissionAsDropDown() : base("[Flow].[FormPermission]")
        {
        }
    }
}
