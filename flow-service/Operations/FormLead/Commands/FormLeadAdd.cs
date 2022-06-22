using Flow.Operations.FormLead.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLead.Commands
{
    public class FormLeadAdd : SaanaaDbInsertAsync<FormLeadAddInDto>
    {
        public FormLeadAdd() : base("[Flow].[FormLead]",
            @"[FormId]",
            @"@FormId")
        {
        }
    }
}

