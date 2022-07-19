using Core.Meteor;

namespace Flow.Operations.WorkflowLead.Queries
{
    public class GetWorkflowLeadByIds : DbQueryByIds<WorkflowLead>
    {
        public GetWorkflowLeadByIds() : base("[Flow].[WorkflowLead]")
        {
        }
    }
}