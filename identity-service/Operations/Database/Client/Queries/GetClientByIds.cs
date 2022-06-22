using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Client.Queries
{
    public class GetClientByIds : SaanaaDbQueryByIds<Client>
    {
        public GetClientByIds() : base("[Identity].[Client]")
        {
        }
    }
}