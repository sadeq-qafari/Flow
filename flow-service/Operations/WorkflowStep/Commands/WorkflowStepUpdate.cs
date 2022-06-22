using Flow.Operations.WorkflowStep.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowStep.Commands
{
    public class WorkflowStepUpdate : SaanaaDbUpdateAsync<WorkflowStepUpdateInDto>
    {
        public WorkflowStepUpdate() : base("[Flow].[WorkflowStep]",
            @"[WorkflowId]=@WorkflowId,
					[Title]=@Title,
					[Index]=@Index,
					[DeterminerTypeLookup]=@DeterminerTypeLookup,
					[RoleId]=@RoleId,
					[UserId]=@UserId,
					[Conditions]=@Conditions,
					[AcceptWorkflowStepId]=@AcceptWorkflowStepId,
					[RejectWorkflowStepId]=@RejectWorkflowStepId,
					[AcceptText]=@AcceptText,
					[RejectText]=@RejectText,
					[MessageId]=@MessageId,
					[IsLastStep]=@IsLastStep,
					[Url]=@Url,
					[Description]=@Description,
					[Guidance]=@Guidance,
					[ShowReject]=@ShowReject")
        {
        }
    }
}