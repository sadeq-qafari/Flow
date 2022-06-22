using Saanaa.Core.Meteor;

namespace Flow.Operations.Element.Commands
{
    public class ElementRemove : SaanaaDbDeleteAsync
    {
        public ElementRemove() : base("[Flow].[Element]")
        {
        }
    }
}