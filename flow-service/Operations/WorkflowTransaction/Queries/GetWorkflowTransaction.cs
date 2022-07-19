using Core.Meteor;

namespace Flow.Operations.WorkflowTransaction.Queries
{
    public class GetWorkflowTransaction : DbSelectAsync<WorkflowTransaction?>
    {
        public GetWorkflowTransaction() : base("[Flow].[WorkflowTransaction]")
        {
        }
    }
}