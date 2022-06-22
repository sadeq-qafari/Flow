using Core.Operations.ServiceConfig.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ServiceConfig.Queries
{
    public class GetServiceConfigPage : SaanaaDbQueryPage<ServiceConfigDto>
    {
        public GetServiceConfigPage() : base("[Core].[ServiceConfig]")
        {
        }
        
    }
}
