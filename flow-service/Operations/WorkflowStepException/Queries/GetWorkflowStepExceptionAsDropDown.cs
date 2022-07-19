using Core.Meteor;

namespace Flow.Operations.WorkflowStepException.Queries
{
    public class GetWorkflowStepExceptionAsDropDown : DbQueryAsDropDown<WorkflowStepException>
    {
        public GetWorkflowStepExceptionAsDropDown() : base("[Flow].[WorkflowStepException]")
        {
        }
    }
}
