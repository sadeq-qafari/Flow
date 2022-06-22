using Saanaa.Core.Meteor;

namespace Core.Operations.Service.Commands
{
    public class RemoveService : SaanaaDbDeleteAsync
    {
        public RemoveService() : base("[Core].[Service]")
        {
        }
    }
}
