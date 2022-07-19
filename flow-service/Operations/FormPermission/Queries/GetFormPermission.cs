using Core.Meteor;

namespace Flow.Operations.FormPermission.Queries
{
    public class GetFormPermission : DbSelectAsync<FormPermission?>
    {
        public GetFormPermission() : base("[Flow].[FormPermission]")
        {
        }
    }
}