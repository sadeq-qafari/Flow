using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowLead.Queries
{
    public class GetWorkflowLeadAsDropDown : SaanaaDbQueryAsDropDown<WorkflowLead>
    {
        public GetWorkflowLeadAsDropDown() : base("[Flow].[WorkflowLead]")
        {
        }
    }
}
