using Core.Meteor;

namespace Flow.Operations.FormPermission.Queries
{
    public class GetFormPermissionByIds : DbQueryByIds<FormPermission>
    {
        public GetFormPermissionByIds() : base("[Flow].[FormPermission]")
        {
        }
    }
}