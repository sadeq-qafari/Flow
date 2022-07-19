using Core.Meteor;

namespace Core.Operations.Service.Queries
{
    public class GetServiceAsDropDown : DbQueryAsDropDown<Service>
    {
        public GetServiceAsDropDown() : base("[Core].[Service]")
        {
        }
    }
}
