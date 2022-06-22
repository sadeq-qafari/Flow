using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.WorkflowStepException.Dtos
{
    public class WorkflowStepExceptionAddInDto : SaanaaDbInsertInDto
    {
        public int WorkFlowStepId { get; set; }
        public int FormPropertyId { get; set; }
        public bool? IsVisible { get; set; }

    }
}
