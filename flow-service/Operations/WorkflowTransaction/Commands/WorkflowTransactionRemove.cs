using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowTransaction.Commands
{
    public class WorkflowTransactionRemove : SaanaaDbDeleteAsync
    {
        public WorkflowTransactionRemove() : base("[Flow].[WorkflowTransaction]")
        {
        }
    }
}