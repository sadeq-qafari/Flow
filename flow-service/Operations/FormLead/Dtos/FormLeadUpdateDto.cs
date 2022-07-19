using Core.Meteor.Dto;

namespace Flow.Operations.FormLead.Dtos
{
    public class FormLeadUpdateInDto : DbUpdateInDto
    {
        public int FormId { get; set; }

    }
}
