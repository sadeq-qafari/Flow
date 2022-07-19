using Core.Meteor;

namespace Flow.Operations.Workflow.Queries
{
    public class GetWorkflowByIds : DbQueryByIds<Workflow>
    {
        public GetWorkflowByIds() : base("[Flow].[Workflow]")
        {
        }
    }
}