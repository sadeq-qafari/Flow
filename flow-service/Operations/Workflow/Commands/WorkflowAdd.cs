using Core.Meteor;
using Flow.Operations.Workflow.Dtos;

namespace Flow.Operations.Workflow.Commands
{
    public class WorkflowAdd : DbInsertAsync<WorkflowAddInDto>
    {
        public WorkflowAdd() : base("[Flow].[Workflow]",
            @"[Title],
						[Description]",
            @"@Title,
						@Description")
        {
        }
    }
}

