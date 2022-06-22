using Saanaa.Core.Meteor;

namespace Flow.Operations.Workflow.Commands
{
    public class WorkflowRemove : SaanaaDbDeleteAsync
    {
        public WorkflowRemove() : base("[Flow].[Workflow]")
        {
        }
    }
}