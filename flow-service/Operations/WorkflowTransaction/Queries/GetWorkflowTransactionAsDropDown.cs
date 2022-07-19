using Core.Meteor;

namespace Flow.Operations.WorkflowTransaction.Queries
{
    public class GetWorkflowTransactionAsDropDown : DbQueryAsDropDown<WorkflowTransaction>
    {
        public GetWorkflowTransactionAsDropDown() : base("[Flow].[WorkflowTransaction]")
        {
        }
    }
}
