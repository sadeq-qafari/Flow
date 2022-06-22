using Flow.Operations.FormLead.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLead.Commands
{
    public class FormLeadUpdate : SaanaaDbUpdateAsync<FormLeadUpdateInDto>
    {
        public FormLeadUpdate() : base("[Flow].[FormLead]",
            @"[FormId]=@FormId")
        {
        }
    }
}