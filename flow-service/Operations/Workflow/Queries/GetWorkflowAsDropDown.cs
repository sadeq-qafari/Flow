using Core.Meteor;

namespace Flow.Operations.Workflow.Queries
{
    public class GetWorkflowAsDropDown : DbQueryAsDropDown<Workflow>
    {
        public GetWorkflowAsDropDown() : base("[Flow].[Workflow]")
        {
        }
    }
}
