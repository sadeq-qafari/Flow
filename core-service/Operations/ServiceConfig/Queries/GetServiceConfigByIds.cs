using Saanaa.Core.Meteor;

namespace Core.Operations.ServiceConfig.Queries
{
    public class GetServiceConfigByIds : SaanaaDbQueryByIds<ServiceConfig>
    {
        public GetServiceConfigByIds() : base("[Core].[ServiceConfig]")
        {
        }
    }
}
