using Core.Meteor;

namespace Flow.Operations.Workflow.Commands
{
    public class WorkflowRemove : DbDeleteAsync
    {
        public WorkflowRemove() : base("[Flow].[Workflow]")
        {
        }
    }
}