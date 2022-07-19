using System;
using Core.Meteor.Dto;

namespace Flow.Operations.WorkflowLead.Dtos
{
    public class WorkflowLeadUpdateInDto : DbUpdateInDto
    {
        public int? CurrentWorkflowStepId { get; set; }
        public DateTime LatestActionDate { get; set; }
        public int? StatusLookup { get; set; }

    }
}
