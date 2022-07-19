using Core.Meteor;

namespace Identity.Operations.Database.Client.Commands
{
    public class ClientRemove : DbDeleteAsync
    {
        public ClientRemove() : base("[Identity].[Client]")
        {
        }
    }
}