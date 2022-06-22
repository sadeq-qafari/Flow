using Saanaa.Core.Meteor;

namespace Flow.Operations.Workflow.Queries
{
    public class GetWorkflowAsDropDown : SaanaaDbQueryAsDropDown<Workflow>
    {
        public GetWorkflowAsDropDown() : base("[Flow].[Workflow]")
        {
        }
    }
}
