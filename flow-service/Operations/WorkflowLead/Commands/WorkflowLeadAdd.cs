using Core.Meteor;
using Flow.Operations.WorkflowLead.Dtos;

namespace Flow.Operations.WorkflowLead.Commands
{
    public class WorkflowLeadAdd : DbInsertAsync<WorkflowLeadAddInDto>
    {
        public WorkflowLeadAdd() : base("[Flow].[WorkflowLead]",
            @"[CurrentWorkflowStepId],
						[LatestActionDate],
						[StatusLookup]",
            @"@CurrentWorkflowStepId,
						@LatestActionDate,
						@StatusLookup")
        {
        }
    }
}

