using Core.Meteor;

namespace Core.Operations.ServiceConfig.Queries
{
    public class GetServiceConfigAsDropDown : DbQueryAsDropDown<ServiceConfig>
    {
        public GetServiceConfigAsDropDown() : base("[Core].[ServiceConfig]")
        {
        }
    }
}
