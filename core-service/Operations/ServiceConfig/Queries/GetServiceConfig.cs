using Saanaa.Core.Meteor;

namespace Core.Operations.ServiceConfig.Queries
{
    public class GetServiceConfig : SaanaaDbSelectAsync<ServiceConfig?>
    {
        public GetServiceConfig() : base("[Core].[ServiceConfig]")
        {
        }
    }
}
