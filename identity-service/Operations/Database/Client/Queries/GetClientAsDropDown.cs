using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Client.Queries
{
    public class GetClientAsDropDown : SaanaaDbQueryAsDropDown<Client>
    {
        public GetClientAsDropDown() : base("[Identity].[Client]")
        {
        }
    }
}
