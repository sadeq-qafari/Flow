using Saanaa.Core.Meteor;

namespace Tenant.Operations.Transaction.Queries
{
    public class GetTransaction : SaanaaDbSelectAsync<Transaction?>
    {
        public GetTransaction() : base("[Tenant].[Transaction]")
        {
        }
    }
}