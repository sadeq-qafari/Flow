using Core.Meteor;

namespace Core.Operations.ServiceConfig.Queries
{
    public class GetServiceConfig : DbSelectAsync<ServiceConfig?>
    {
        public GetServiceConfig() : base("[Core].[ServiceConfig]")
        {
        }
    }
}
