using Core.Meteor;

namespace Flow.Operations.FormAction.Queries
{
    public class GetFormAction : DbSelectAsync<FormAction?>
    {
        public GetFormAction() : base("[Flow].[FormAction]")
        {
        }
    }
}