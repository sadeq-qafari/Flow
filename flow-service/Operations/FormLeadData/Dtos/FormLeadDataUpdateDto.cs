using Core.Meteor.Dto;

namespace Flow.Operations.FormLeadData.Dtos
{
    public class FormLeadDataUpdateInDto : DbUpdateInDto
    {
        public int FormLeadId { get; set; }
        public int FormPropertyId { get; set; }
        public string? Value { get; set; }

    }
}
