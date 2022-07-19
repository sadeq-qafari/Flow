using Core.Meteor;
using Flow.Operations.WorkflowStepException.Dtos;

namespace Flow.Operations.WorkflowStepException.Commands
{
    public class WorkflowStepExceptionUpdate : DbUpdateAsync<WorkflowStepExceptionUpdateInDto>
    {
        public WorkflowStepExceptionUpdate() : base("[Flow].[WorkflowStepException]",
            @"[WorkFlowStepId]=@WorkFlowStepId,
					[FormPropertyId]=@FormPropertyId,
					[IsVisible]=@IsVisible")
        {
        }
    }
}