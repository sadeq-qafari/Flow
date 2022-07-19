using Core.Meteor;

namespace Flow.Operations.WorkflowStepException.Queries
{
    public class GetWorkflowStepExceptionByIds : DbQueryByIds<WorkflowStepException>
    {
        public GetWorkflowStepExceptionByIds() : base("[Flow].[WorkflowStepException]")
        {
        }
    }
}