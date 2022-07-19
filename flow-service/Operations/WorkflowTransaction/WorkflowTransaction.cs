using Core.Meteor;
using Core.Meteor.Dto;

namespace Flow.Operations.WorkflowTransaction
{
    public class WorkflowTransaction : BaseModelDto, IDropDown
    {
        public int WorkflowLeadId { get; set; }
        public int? WorkflowStepId { get; set; }
        public int? ActionTypeLookup { get; set; }
        public string? Comment { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
