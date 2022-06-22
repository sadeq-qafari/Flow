using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowTransaction.Queries
{
    public class GetWorkflowTransaction : SaanaaDbSelectAsync<WorkflowTransaction?>
    {
        public GetWorkflowTransaction() : base("[Flow].[WorkflowTransaction]")
        {
        }
    }
}