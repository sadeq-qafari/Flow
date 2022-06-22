using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyElement.Commands
{
    public class RemoveModelPropertyElement : SaanaaDbDeleteAsync
    {
        public RemoveModelPropertyElement() : base("[Core].[ModelPropertyElement]")
        {
        }
    }
}
