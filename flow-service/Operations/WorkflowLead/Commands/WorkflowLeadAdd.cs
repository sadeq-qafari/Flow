using Flow.Operations.WorkflowLead.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowLead.Commands
{
    public class WorkflowLeadAdd : SaanaaDbInsertAsync<WorkflowLeadAddInDto>
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

