using Core.Meteor;
using Flow.Operations.Workflow.Dtos;

namespace Flow.Operations.Workflow.Commands
{
    public class WorkflowUpdate : DbUpdateAsync<WorkflowUpdateInDto>
    {
        public WorkflowUpdate() : base("[Flow].[Workflow]",
            @"[Title]=@Title,
					[Description]=@Description")
        {
        }
    }
}