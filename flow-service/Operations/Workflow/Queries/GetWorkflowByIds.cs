using Saanaa.Core.Meteor;

namespace Flow.Operations.Workflow.Queries
{
    public class GetWorkflowByIds : SaanaaDbQueryByIds<Workflow>
    {
        public GetWorkflowByIds() : base("[Flow].[Workflow]")
        {
        }
    }
}