using Core.Meteor;

namespace Core.Operations.Service.Queries
{
    public class GetServiceByIds : DbQueryByIds<Service>
    {
        public GetServiceByIds() : base("[Core].[Service]")
        {
        }
    }
}
