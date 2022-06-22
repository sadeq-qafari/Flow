using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowStep.Queries
{
    public class GetWorkflowStepAsDropDown : SaanaaDbQueryAsDropDown<WorkflowStep>
    {
        public GetWorkflowStepAsDropDown() : base("[Flow].[WorkflowStep]")
        {
        }
    }
}
