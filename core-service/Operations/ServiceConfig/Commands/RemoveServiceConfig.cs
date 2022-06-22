using Saanaa.Core.Meteor;

namespace Core.Operations.ServiceConfig.Commands
{
    public class RemoveServiceConfig : SaanaaDbDeleteAsync
    {
        public RemoveServiceConfig() : base("[Core].[ServiceConfig]")
        {
        }
    }
}
