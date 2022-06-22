using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowStep.Commands
{
    public class WorkflowStepRemove : SaanaaDbDeleteAsync
    {
        public WorkflowStepRemove() : base("[Flow].[WorkflowStep]")
        {
        }
    }
}