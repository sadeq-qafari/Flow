using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowLead.Queries
{
    public class GetWorkflowLead : SaanaaDbSelectAsync<WorkflowLead?>
    {
        public GetWorkflowLead() : base("[Flow].[WorkflowLead]")
        {
        }
    }
}