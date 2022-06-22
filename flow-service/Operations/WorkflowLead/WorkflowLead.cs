using System;
using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.WorkflowLead
{
    public class WorkflowLead : BaseModelDto, IDropDown
    {
        public int? CurrentWorkflowStepId { get; set; }
        public DateTime LatestActionDate { get; set; }
        public int? StatusLookup { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
