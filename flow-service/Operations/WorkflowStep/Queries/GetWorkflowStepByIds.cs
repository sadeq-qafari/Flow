using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowStep.Queries
{
    public class GetWorkflowStepByIds : SaanaaDbQueryByIds<WorkflowStep>
    {
        public GetWorkflowStepByIds() : base("[Flow].[WorkflowStep]")
        {
        }
    }
}