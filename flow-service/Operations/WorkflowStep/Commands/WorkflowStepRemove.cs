using Core.Meteor;

namespace Flow.Operations.WorkflowStep.Commands
{
    public class WorkflowStepRemove : DbDeleteAsync
    {
        public WorkflowStepRemove() : base("[Flow].[WorkflowStep]")
        {
        }
    }
}