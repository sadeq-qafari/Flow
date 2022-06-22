using Saanaa.Core.Meteor;

namespace Flow.Operations.Workflow.Queries
{
    public class GetWorkflow : SaanaaDbSelectAsync<Workflow?>
    {
        public GetWorkflow() : base("[Flow].[Workflow]")
        {
        }
    }
}