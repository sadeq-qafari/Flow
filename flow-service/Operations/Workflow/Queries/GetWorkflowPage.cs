using Core.Meteor;
using Flow.Operations.Workflow.Dtos;

namespace Flow.Operations.Workflow.Queries
{
    public class GetWorkflowPage : DbQueryPage<WorkflowDto>
    {
        public GetWorkflowPage() : base("[Flow].[Workflow]")
        {
        }
        
    }
}