using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowLead.Commands
{
    public class WorkflowLeadRemove : SaanaaDbDeleteAsync
    {
        public WorkflowLeadRemove() : base("[Flow].[WorkflowLead]")
        {
        }
    }
}