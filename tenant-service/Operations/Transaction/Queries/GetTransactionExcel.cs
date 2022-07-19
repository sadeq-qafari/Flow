using Core.Meteor;

namespace Tenant.Operations.Transaction.Queries
{
    public class GetTransactionExcel : DbQueryExcel<Transaction>
    {
        public GetTransactionExcel() : base("[Tenant].[Transaction]")
        {
        }
    }
}