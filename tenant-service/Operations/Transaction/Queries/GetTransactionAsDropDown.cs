using Core.Meteor;

namespace Tenant.Operations.Transaction.Queries
{
    public class GetTransactionAsDropDown : DbQueryAsDropDown<Transaction>
    {
        public GetTransactionAsDropDown() : base("[Tenant].[Transaction]")
        {
        }
    }
}
