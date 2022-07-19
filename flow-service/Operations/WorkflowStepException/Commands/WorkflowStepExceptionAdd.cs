using Core.Meteor;
using Flow.Operations.WorkflowStepException.Dtos;

namespace Flow.Operations.WorkflowStepException.Commands
{
    public class WorkflowStepExceptionAdd : DbInsertAsync<WorkflowStepExceptionAddInDto>
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

