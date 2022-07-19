using Core.Meteor;

namespace Tenant.Operations.Transaction.Queries
{
    public class GetTransaction : DbSelectAsync<Transaction?>
    {
        public GetTransaction() : base("[Tenant].[Transaction]")
        {
        }
    }
}