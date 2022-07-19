using Core.Meteor;

namespace Core.Operations.ModelProperty.Commands
{
    public class RemoveModelProperty : DbDeleteAsync
    {
        public RemoveModelProperty() : base("[Core].[ModelProperty]")
        {
        }
    }
}
