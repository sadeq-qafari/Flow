using Core.Meteor;

namespace Flow.Operations.WorkflowStep.Queries
{
    public class GetWorkflowStep : DbSelectAsync<WorkflowStep?>
    {
        public GetWorkflowStep() : base("[Flow].[WorkflowStep]")
        {
        }
    }
}