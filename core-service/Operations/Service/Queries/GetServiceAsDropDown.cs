using Saanaa.Core.Meteor;

namespace Core.Operations.Service.Queries
{
    public class GetServiceAsDropDown : SaanaaDbQueryAsDropDown<Service>
    {
        public GetServiceAsDropDown() : base("[Core].[Service]")
        {
        }
    }
}
