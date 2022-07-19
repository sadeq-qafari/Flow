using Core.Meteor;
using Flow.Operations.WorkflowLead.Dtos;

namespace Flow.Operations.WorkflowLead.Commands
{
    public class WorkflowLeadUpdate : DbUpdateAsync<WorkflowLeadUpdateInDto>
    {
        public WorkflowLeadUpdate() : base("[Flow].[WorkflowLead]",
            @"[CurrentWorkflowStepId]=@CurrentWorkflowStepId,
					[LatestActionDate]=@LatestActionDate,
					[StatusLookup]=@StatusLookup")
        {
        }
    }
}