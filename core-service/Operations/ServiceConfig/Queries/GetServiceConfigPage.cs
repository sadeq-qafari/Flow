using Core.Meteor;
using Core.Operations.ServiceConfig.Dto;

namespace Core.Operations.ServiceConfig.Queries
{
    public class GetServiceConfigPage : DbQueryPage<ServiceConfigDto>
    {
        public GetServiceConfigPage() : base("[Core].[ServiceConfig]")
        {
        }
        
    }
}
