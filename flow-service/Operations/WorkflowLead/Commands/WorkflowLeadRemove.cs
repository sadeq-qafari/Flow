using Core.Meteor;

namespace Flow.Operations.WorkflowLead.Commands
{
    public class WorkflowLeadRemove : DbDeleteAsync
    {
        public WorkflowLeadRemove() : base("[Flow].[WorkflowLead]")
        {
        }
    }
}