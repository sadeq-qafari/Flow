using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyLookup.Commands
{
    public class RemoveModelPropertyLookup : SaanaaDbDeleteAsync
    {
        public RemoveModelPropertyLookup() : base("[Core].[ModelPropertyLookup]")
        {
        }
    }
}
