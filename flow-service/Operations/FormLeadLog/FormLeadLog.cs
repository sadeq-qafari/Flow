using Core.Meteor;
using Core.Meteor.Dto;

namespace Flow.Operations.FormLeadLog
{
    public class FormLeadLog : BaseModelDto, IDropDown
    {
        public int? FormLeadId { get; set; }
        public int FormId { get; set; }
        public int? ActionLookup { get; set; }
        public string? ActionName { get; set; }
        public string? Result { get; set; }
        public string? FormData { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
