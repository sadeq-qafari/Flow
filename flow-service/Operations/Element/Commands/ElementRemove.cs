using Core.Meteor;

namespace Flow.Operations.Element.Commands
{
    public class ElementRemove : DbDeleteAsync
    {
        public ElementRemove() : base("[Flow].[Element]")
        {
        }
    }
}