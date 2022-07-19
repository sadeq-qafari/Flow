using Core.Meteor;

namespace Identity.Operations.Database.Client.Queries
{
    public class GetClientAsDropDown : DbQueryAsDropDown<Client>
    {
        public GetClientAsDropDown() : base("[Identity].[Client]")
        {
        }
    }
}
