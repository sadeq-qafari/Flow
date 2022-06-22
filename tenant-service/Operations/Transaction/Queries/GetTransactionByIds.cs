using Saanaa.Core.Meteor;

namespace Tenant.Operations.Transaction.Queries
{
    public class GetTransactionByIds : SaanaaDbQueryByIds<Transaction>
    {
        public GetTransactionByIds() : base("[Tenant].[Transaction]")
        {
        }
    }
}