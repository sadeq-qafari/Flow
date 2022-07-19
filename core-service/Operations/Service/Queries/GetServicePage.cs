using Core.Meteor;
using Core.Operations.Service.Dto;

namespace Core.Operations.Service.Queries
{
    public class GetServicePage : DbQueryPage<ServiceDto>
    {
        public GetServicePage() : base("[Core].[Service]")
        {
        }
        
    }
}
