using Core.Meteor;
using Flow.Operations.WorkflowTransaction.Dtos;

namespace Flow.Operations.WorkflowTransaction.Commands
{
    public class WorkflowTransactionAdd : DbInsertAsync<WorkflowTransactionAddInDto>
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

