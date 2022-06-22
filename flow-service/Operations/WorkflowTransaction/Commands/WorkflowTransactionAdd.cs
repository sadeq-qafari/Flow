using Flow.Operations.WorkflowTransaction.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowTransaction.Commands
{
    public class WorkflowTransactionAdd : SaanaaDbInsertAsync<WorkflowTransactionAddInDto>
    {
        public WorkflowTransactionAdd() : base("[Flow].[WorkflowTransaction]",
            @"[WorkflowLeadId],
						[WorkflowStepId],
						[ActionTypeLookup],
						[Comment]",
            @"@WorkflowLeadId,
						@WorkflowStepId,
						@ActionTypeLookup,
						@Comment")
        {
        }
    }
}

