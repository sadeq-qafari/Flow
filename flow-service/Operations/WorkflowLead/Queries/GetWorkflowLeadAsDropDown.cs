using Core.Meteor;

namespace Flow.Operations.WorkflowLead.Queries
{
    public class GetWorkflowLeadAsDropDown : DbQueryAsDropDown<WorkflowLead>
    {
        public GetWorkflowLeadAsDropDown() : base("[Flow].[WorkflowLead]")
        {
        }
    }
}
