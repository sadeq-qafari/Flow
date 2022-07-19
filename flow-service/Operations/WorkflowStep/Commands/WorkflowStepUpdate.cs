using Core.Meteor;
using Flow.Operations.WorkflowStep.Dtos;

namespace Flow.Operations.WorkflowStep.Commands
{
    public class WorkflowStepUpdate : DbUpdateAsync<WorkflowStepUpdateInDto>
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