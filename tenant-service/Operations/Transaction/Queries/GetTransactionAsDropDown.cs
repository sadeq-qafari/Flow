using Saanaa.Core.Meteor;

namespace Tenant.Operations.Transaction.Queries
{
    public class GetTransactionAsDropDown : SaanaaDbQueryAsDropDown<Transaction>
    {
        public GetTransactionAsDropDown() : base("[Tenant].[Transaction]")
        {
        }
    }
}
