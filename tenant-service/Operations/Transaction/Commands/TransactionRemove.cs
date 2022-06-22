using Saanaa.Core.Meteor;

namespace Tenant.Operations.Transaction.Commands
{
    public class TransactionRemove : SaanaaDbDeleteAsync
    {
        public TransactionRemove() : base("[Tenant].[Transaction]")
        {
        }
    }
}