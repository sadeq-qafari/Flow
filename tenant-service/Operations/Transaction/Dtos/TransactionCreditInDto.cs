using Saanaa.Core.Meteor;

namespace Tenant.Operations.Transaction.Dtos
{
    public class TransactionCreditInDto : IHaveTenant
    {
        public int PersonId { get; set; }
        public int? TenantId { get; set; }
    }
}
