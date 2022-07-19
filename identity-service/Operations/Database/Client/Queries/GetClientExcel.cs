using Core.Meteor;

namespace Identity.Operations.Database.Client.Queries
{
    public class GetClientExcel : DbQueryExcel<Client>
    {
        public GetClientExcel() : base("[Identity].[Client]")
        {
        }
    }
}