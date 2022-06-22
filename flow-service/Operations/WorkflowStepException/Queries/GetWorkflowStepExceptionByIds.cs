using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowStepException.Queries
{
    public class GetWorkflowStepExceptionByIds : SaanaaDbQueryByIds<WorkflowStepException>
    {
        public GetWorkflowStepExceptionByIds() : base("[Flow].[WorkflowStepException]")
        {
        }
    }
}