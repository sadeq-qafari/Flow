using Flow.Operations.WorkflowStepException.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowStepException.Commands
{
    public class WorkflowStepExceptionAdd : SaanaaDbInsertAsync<WorkflowStepExceptionAddInDto>
    {
        public WorkflowStepExceptionAdd() : base("[Flow].[WorkflowStepException]",
            @"[WorkFlowStepId],
						[FormPropertyId],
						[IsVisible]",
            @"@WorkFlowStepId,
						@FormPropertyId,
						@IsVisible")
        {
        }
    }
}

