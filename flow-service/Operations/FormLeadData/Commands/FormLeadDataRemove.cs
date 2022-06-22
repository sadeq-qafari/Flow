using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLeadData.Commands
{
    public class FormLeadDataRemove : SaanaaDbDeleteAsync
    {
        public FormLeadDataRemove() : base("[Flow].[FormLeadData]")
        {
        }
    }
}