using Core.Meteor;
using Flow.Operations.WorkflowStep.Dtos;

namespace Flow.Operations.WorkflowStep.Commands
{
    public class WorkflowStepAdd : DbInsertAsync<WorkflowStepAddInDto>
    {
        public WorkflowStepAdd() : base("[Flow].[WorkflowStep]",
            @"[WorkflowId],
						[Title],
						[Index],
						[DeterminerTypeLookup],
						[RoleId],
						[UserId],
						[Conditions],
						[AcceptWorkflowStepId],
						[RejectWorkflowStepId],
						[AcceptText],
						[RejectText],
						[MessageId],
						[IsLastStep],
						[Url],
						[Description],
						[Guidance],
						[ShowReject]",
            @"@WorkflowId,
						@Title,
						@Index,
						@DeterminerTypeLookup,
						@RoleId,
						@UserId,
						@Conditions,
						@AcceptWorkflowStepId,
						@RejectWorkflowStepId,
						@AcceptText,
						@RejectText,
						@MessageId,
						@IsLastStep,
						@Url,
						@Description,
						@Guidance,
						@ShowReject")
        {
        }
    }
}

