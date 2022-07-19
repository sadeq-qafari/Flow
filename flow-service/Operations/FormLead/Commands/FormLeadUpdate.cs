using Core.Meteor;
using Flow.Operations.FormLead.Dtos;

namespace Flow.Operations.FormLead.Commands
{
    public class FormLeadUpdate : DbUpdateAsync<FormLeadUpdateInDto>
    {
        public FormLeadUpdate() : base("[Flow].[FormLead]",
            @"[FormId]=@FormId")
        {
        }
    }
}