using Core.Meteor;

namespace Flow.Operations.WorkflowStep.Queries
{
    public class GetWorkflowStepAsDropDown : DbQueryAsDropDown<WorkflowStep>
    {
        public GetWorkflowStepAsDropDown() : base("[Flow].[WorkflowStep]")
        {
        }
    }
}
