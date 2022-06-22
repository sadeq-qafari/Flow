using Saanaa.Core.Meteor;

namespace Flow.Operations.FormAction.Commands
{
    public class FormActionRemove : SaanaaDbDeleteAsync
    {
        public FormActionRemove() : base("[Flow].[FormAction]")
        {
        }
    }
}