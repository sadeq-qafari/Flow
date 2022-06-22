using Saanaa.Core.Meteor;

namespace Core.Operations.Service.Queries
{
    public class GetServiceByIds : SaanaaDbQueryByIds<Service>
    {
        public GetServiceByIds() : base("[Core].[Service]")
        {
        }
    }
}
