using Flow.Operations.WorkflowTransaction.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowTransaction.Commands
{
    public class WorkflowTransactionUpdate : SaanaaDbUpdateAsync<WorkflowTransactionUpdateInDto>
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