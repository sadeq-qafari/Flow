using Core.Meteor;

namespace Tenant.Operations.Transaction.Queries
{
    public class GetTransactionByIds : DbQueryByIds<Transaction>
    {
        public GetTransactionByIds() : base("[Tenant].[Transaction]")
        {
        }
    }
}