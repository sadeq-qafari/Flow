using Saanaa.Core.Meteor;

namespace Flow.Operations.FormProperty.Commands
{
    public class FormPropertyRemove : SaanaaDbDeleteAsync
    {
        public FormPropertyRemove() : base("[Flow].[FormProperty]")
        {
        }
    }
}