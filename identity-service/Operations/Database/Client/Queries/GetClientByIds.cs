using Core.Meteor;

namespace Identity.Operations.Database.Client.Queries
{
    public class GetClientByIds : DbQueryByIds<Client>
    {
        public GetClientByIds() : base("[Identity].[Client]")
        {
        }
    }
}