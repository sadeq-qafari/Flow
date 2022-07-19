using Core.Meteor;

namespace Flow.Operations.WorkflowTransaction.Queries
{
    public class GetWorkflowTransactionByIds : DbQueryByIds<WorkflowTransaction>
    {
        public GetWorkflowTransactionByIds() : base("[Flow].[WorkflowTransaction]")
        {
        }
    }
}