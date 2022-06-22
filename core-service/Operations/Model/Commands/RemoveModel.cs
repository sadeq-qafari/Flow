using Saanaa.Core.Meteor;

namespace Core.Operations.Model.Commands
{
    public class RemoveModel : SaanaaDbDeleteAsync
    {
        public RemoveModel() : base("[Core].[Model]")
        {
        }
    }
}
