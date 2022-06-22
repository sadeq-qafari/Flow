using Flow.Operations.WorkflowStepException.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowStepException.Commands
{
    public class WorkflowStepExceptionUpdate : SaanaaDbUpdateAsync<WorkflowStepExceptionUpdateInDto>
    {
        public WorkflowStepExceptionUpdate() : base("[Flow].[WorkflowStepException]",
            @"[WorkFlowStepId]=@WorkFlowStepId,
					[FormPropertyId]=@FormPropertyId,
					[IsVisible]=@IsVisible")
        {
        }
    }
}