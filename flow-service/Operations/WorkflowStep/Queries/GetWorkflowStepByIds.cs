using Core.Meteor;

namespace Flow.Operations.WorkflowStep.Queries
{
    public class GetWorkflowStepByIds : DbQueryByIds<WorkflowStep>
    {
        public GetWorkflowStepByIds() : base("[Flow].[WorkflowStep]")
        {
        }
    }
}