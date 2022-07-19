using Core.Meteor;

namespace Flow.Operations.WorkflowStepException.Commands
{
    public class WorkflowStepExceptionRemove : DbDeleteAsync
    {
        public WorkflowStepExceptionRemove() : base("[Flow].[WorkflowStepException]")
        {
        }
    }
}