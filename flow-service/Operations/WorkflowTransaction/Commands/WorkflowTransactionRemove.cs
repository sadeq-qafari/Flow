using Core.Meteor;

namespace Flow.Operations.WorkflowTransaction.Commands
{
    public class WorkflowTransactionRemove : DbDeleteAsync
    {
        public WorkflowTransactionRemove() : base("[Flow].[WorkflowTransaction]")
        {
        }
    }
}