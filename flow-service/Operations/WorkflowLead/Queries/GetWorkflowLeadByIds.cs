using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowLead.Queries
{
    public class GetWorkflowLeadByIds : SaanaaDbQueryByIds<WorkflowLead>
    {
        public GetWorkflowLeadByIds() : base("[Flow].[WorkflowLead]")
        {
        }
    }
}