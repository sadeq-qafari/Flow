using Core.Meteor;

namespace Flow.Operations.WorkflowLead.Queries
{
    public class GetWorkflowLead : DbSelectAsync<WorkflowLead?>
    {
        public GetWorkflowLead() : base("[Flow].[WorkflowLead]")
        {
        }
    }
}