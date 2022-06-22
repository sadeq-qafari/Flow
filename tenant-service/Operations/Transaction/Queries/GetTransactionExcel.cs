using Saanaa.Core.Meteor;

namespace Tenant.Operations.Transaction.Queries
{
    public class GetTransactionExcel : SaanaaDbQueryExcel<Transaction>
    {
        public GetTransactionExcel() : base("[Tenant].[Transaction]")
        {
        }
    }
}