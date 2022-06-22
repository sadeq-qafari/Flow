using Saanaa.Core.Meteor;

namespace Core.Operations.ServiceConfig.Queries
{
    public class GetServiceConfigAsDropDown : SaanaaDbQueryAsDropDown<ServiceConfig>
    {
        public GetServiceConfigAsDropDown() : base("[Core].[ServiceConfig]")
        {
        }
    }
}
