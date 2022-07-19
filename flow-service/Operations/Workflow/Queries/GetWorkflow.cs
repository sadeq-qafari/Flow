using Core.Meteor;

namespace Flow.Operations.Workflow.Queries
{
    public class GetWorkflow : DbSelectAsync<Workflow?>
    {
        public GetWorkflow() : base("[Flow].[Workflow]")
        {
        }
    }
}