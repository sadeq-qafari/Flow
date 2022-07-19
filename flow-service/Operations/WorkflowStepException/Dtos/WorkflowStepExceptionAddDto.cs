using Core.Meteor.Dto;

namespace Flow.Operations.WorkflowStepException.Dtos
{
    public class WorkflowStepExceptionAddInDto : DbInsertInDto
    {
        public int WorkFlowStepId { get; set; }
        public int FormPropertyId { get; set; }
        public bool? IsVisible { get; set; }

    }
}
