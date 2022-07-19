using Core.Meteor;

namespace Core.Operations.Service.Queries
{
    public class GetService : DbSelectAsync<Service?>
    {
        public GetService() : base("[Core].[Service]")
        {
        }
    }
}
