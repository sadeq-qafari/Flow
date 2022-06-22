using Saanaa.Core.Meteor;

namespace Core.Operations.ModelFilter.Commands
{
    public class ModelFilterRemove : SaanaaDbDeleteAsync
    {
        public ModelFilterRemove() : base("[Core].[ModelFilter]")
        {
        }
    }
}