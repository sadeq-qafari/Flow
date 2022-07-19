using Core.Meteor;
using Flow.Operations.FormLead.Dtos;

namespace Flow.Operations.FormLead.Commands
{
    public class FormLeadAdd : DbInsertAsync<FormLeadAddInDto>
    {
        public FormLeadAdd() : base("[Flow].[FormLead]",
            @"[FormId]",
            @"@FormId")
        {
        }
    }
}

