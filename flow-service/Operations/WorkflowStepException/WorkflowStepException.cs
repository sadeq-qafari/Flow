using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.WorkflowStepException
{
    public class WorkflowStepException : BaseModelDto, IDropDown
    {
        public int WorkFlowStepId { get; set; }
        public int FormPropertyId { get; set; }
        public bool? IsVisible { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
