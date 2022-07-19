using Core.Meteor.Dto;

namespace Flow.Operations.FormLeadLog.Dtos
{
    public class FormLeadLogUpdateInDto : DbUpdateInDto
    {
        public int? FormLeadId { get; set; }
        public int FormId { get; set; }
        public int? ActionLookup { get; set; }
        public string? ActionName { get; set; }
        public string? Result { get; set; }
        public string? FormData { get; set; }

    }
}
