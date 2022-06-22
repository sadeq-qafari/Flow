using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowTransaction.Queries
{
    public class GetWorkflowTransactionAsDropDown : SaanaaDbQueryAsDropDown<WorkflowTransaction>
    {
        public GetWorkflowTransactionAsDropDown() : base("[Flow].[WorkflowTransaction]")
        {
        }
    }
}
