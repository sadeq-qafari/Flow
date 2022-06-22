using Flow.Operations.Workflow.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Workflow.Commands
{
    public class WorkflowAdd : SaanaaDbInsertAsync<WorkflowAddInDto>
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

