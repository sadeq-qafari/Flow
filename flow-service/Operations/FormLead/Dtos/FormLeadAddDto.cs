using Core.Meteor.Dto;

namespace Flow.Operations.FormLead.Dtos
{
    public class FormLeadAddInDto : DbInsertInDto
    {
        public int FormId { get; set; }

    }
}
