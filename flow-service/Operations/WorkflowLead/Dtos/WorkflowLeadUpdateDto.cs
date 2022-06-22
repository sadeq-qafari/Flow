using System;
using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.WorkflowLead.Dtos
{
    public class WorkflowLeadUpdateInDto : SaanaaDbUpdateInDto
    {
        public int? CurrentWorkflowStepId { get; set; }
        public DateTime LatestActionDate { get; set; }
        public int? StatusLookup { get; set; }

    }
}
