using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowTransaction.Queries
{
    public class GetWorkflowTransactionByIds : SaanaaDbQueryByIds<WorkflowTransaction>
    {
        public GetWorkflowTransactionByIds() : base("[Flow].[WorkflowTransaction]")
        {
        }
    }
}