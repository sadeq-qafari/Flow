using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLeadLog.Commands
{
    public class FormLeadLogRemove : SaanaaDbDeleteAsync
    {
        public FormLeadLogRemove() : base("[Flow].[FormLeadLog]")
        {
        }
    }
}