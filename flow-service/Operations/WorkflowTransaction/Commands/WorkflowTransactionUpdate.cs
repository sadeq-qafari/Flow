using Core.Meteor;
using Flow.Operations.WorkflowTransaction.Dtos;

namespace Flow.Operations.WorkflowTransaction.Commands
{
    public class WorkflowTransactionUpdate : DbUpdateAsync<WorkflowTransactionUpdateInDto>
    {
        public WorkflowTransactionUpdate() : base("[Flow].[WorkflowTransaction]",
            @"[WorkflowLeadId]=@WorkflowLeadId,
					[WorkflowStepId]=@WorkflowStepId,
					[ActionTypeLookup]=@ActionTypeLookup,
					[Comment]=@Comment")
        {
        }
    }
}