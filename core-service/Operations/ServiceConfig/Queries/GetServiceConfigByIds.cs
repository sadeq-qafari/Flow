using Core.Meteor;

namespace Core.Operations.ServiceConfig.Queries
{
    public class GetServiceConfigByIds : DbQueryByIds<ServiceConfig>
    {
        public GetServiceConfigByIds() : base("[Core].[ServiceConfig]")
        {
        }
    }
}
