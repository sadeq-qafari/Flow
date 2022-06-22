using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Client.Commands
{
    public class ClientRemove : SaanaaDbDeleteAsync
    {
        public ClientRemove() : base("[Identity].[Client]")
        {
        }
    }
}