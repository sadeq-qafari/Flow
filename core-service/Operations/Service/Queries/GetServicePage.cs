using Core.Operations.Service.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.Service.Queries
{
    public class GetServicePage : SaanaaDbQueryPage<ServiceDto>
    {
        public GetServicePage() : base("[Core].[Service]")
        {
        }
        
    }
}
