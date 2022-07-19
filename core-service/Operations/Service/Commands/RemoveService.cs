using Core.Meteor;

namespace Core.Operations.Service.Commands
{
    public class RemoveService : DbDeleteAsync
    {
        public RemoveService() : base("[Core].[Service]")
        {
        }
    }
}
