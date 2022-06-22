using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowStepException.Commands
{
    public class WorkflowStepExceptionRemove : SaanaaDbDeleteAsync
    {
        public WorkflowStepExceptionRemove() : base("[Flow].[WorkflowStepException]")
        {
        }
    }
}