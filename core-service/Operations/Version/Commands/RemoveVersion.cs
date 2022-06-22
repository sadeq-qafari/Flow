using Saanaa.Core.Meteor;

namespace Core.Operations.Version.Commands
{
    public class RemoveVersion : SaanaaDbDeleteAsync
    {
        public RemoveVersion() : base("[Core].[Version]")
        {
        }
    }
}
