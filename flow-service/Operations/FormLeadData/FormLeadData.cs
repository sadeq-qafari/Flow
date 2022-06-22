using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.FormLeadData
{
    public class FormLeadData : BaseModelDto, IDropDown
    {
        public int FormLeadId { get; set; }
        public int FormPropertyId { get; set; }
        public string? Value { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
