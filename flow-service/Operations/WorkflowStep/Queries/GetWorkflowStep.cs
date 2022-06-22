using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowStep.Queries
{
    public class GetWorkflowStep : SaanaaDbSelectAsync<WorkflowStep?>
    {
        public GetWorkflowStep() : base("[Flow].[WorkflowStep]")
        {
        }
    }
}