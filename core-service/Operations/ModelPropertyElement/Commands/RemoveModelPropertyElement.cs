using Core.Meteor;

namespace Core.Operations.ModelPropertyElement.Commands
{
    public class RemoveModelPropertyElement : DbDeleteAsync
    {
        public RemoveModelPropertyElement() : base("[Core].[ModelPropertyElement]")
        {
        }
    }
}
