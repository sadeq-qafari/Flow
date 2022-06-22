using Saanaa.Core.Meteor;

namespace Flow.Operations.Form.Commands
{
    public class FormRemove : SaanaaDbDeleteAsync
    {
        public FormRemove() : base("[Flow].[Form]")
        {
        }
    }
}