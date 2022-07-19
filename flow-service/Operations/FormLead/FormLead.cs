using Core.Meteor;
using Core.Meteor.Dto;

namespace Flow.Operations.FormLead
{
    public class FormLead : BaseModelDto, IDropDown
    {
        public int FormId { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
