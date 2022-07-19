using Core.Meteor;

namespace Flow.Operations.WorkflowStepException.Queries
{
    public class GetWorkflowStepException : DbSelectAsync<WorkflowStepException?>
    {
        public GetWorkflowStepException() : base("[Flow].[WorkflowStepException]")
        {
        }
    }
}