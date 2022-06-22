using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowStepException.Queries
{
    public class GetWorkflowStepException : SaanaaDbSelectAsync<WorkflowStepException?>
    {
        public GetWorkflowStepException() : base("[Flow].[WorkflowStepException]")
        {
        }
    }
}