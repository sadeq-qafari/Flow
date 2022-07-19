using Core.Meteor;

namespace Tenant.Operations.Transaction.Commands
{
    public class TransactionRemove : DbDeleteAsync
    {
        public TransactionRemove() : base("[Tenant].[Transaction]")
        {
        }
    }
}