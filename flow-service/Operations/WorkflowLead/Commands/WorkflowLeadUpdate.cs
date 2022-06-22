using Flow.Operations.WorkflowLead.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowLead.Commands
{
    public class WorkflowLeadUpdate : SaanaaDbUpdateAsync<WorkflowLeadUpdateInDto>
    {
        public WorkflowLeadUpdate() : base("[Flow].[WorkflowLead]",
            @"[CurrentWorkflowStepId]=@CurrentWorkflowStepId,
					[LatestActionDate]=@LatestActionDate,
					[StatusLookup]=@StatusLookup")
        {
        }
    }
}