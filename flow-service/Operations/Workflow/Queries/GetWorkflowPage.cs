using Flow.Operations.Workflow.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Workflow.Queries
{
    public class GetWorkflowPage : SaanaaDbQueryPage<WorkflowDto>
    {
        public GetWorkflowPage() : base("[Flow].[Workflow]")
        {
        }
        
    }
}