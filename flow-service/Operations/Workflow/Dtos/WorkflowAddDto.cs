using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.Workflow.Dtos
{
    public class WorkflowAddInDto : SaanaaDbInsertInDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }

    }
}
