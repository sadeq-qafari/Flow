using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowStepException.Queries
{
    public class GetWorkflowStepExceptionAsDropDown : SaanaaDbQueryAsDropDown<WorkflowStepException>
    {
        public GetWorkflowStepExceptionAsDropDown() : base("[Flow].[WorkflowStepException]")
        {
        }
    }
}
