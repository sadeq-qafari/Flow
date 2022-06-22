using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLead.Commands
{
    public class FormLeadRemove : SaanaaDbDeleteAsync
    {
        public FormLeadRemove() : base("[Flow].[FormLead]")
        {
        }
    }
}