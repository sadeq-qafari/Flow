using Core.Meteor.Dto;

namespace Flow.Operations.Workflow.Dtos
{
    public class WorkflowUpdateInDto : DbUpdateInDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }

    }
}
