using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.WorkflowTransaction.Dtos
{
    public class WorkflowTransactionUpdateInDto : SaanaaDbUpdateInDto
    {
        public int WorkflowLeadId { get; set; }
        public int? WorkflowStepId { get; set; }
        public int? ActionTypeLookup { get; set; }
        public string? Comment { get; set; }

    }
}
