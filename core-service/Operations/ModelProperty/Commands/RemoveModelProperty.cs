using Saanaa.Core.Meteor;

namespace Core.Operations.ModelProperty.Commands
{
    public class RemoveModelProperty : SaanaaDbDeleteAsync
    {
        public RemoveModelProperty() : base("[Core].[ModelProperty]")
        {
        }
    }
}
