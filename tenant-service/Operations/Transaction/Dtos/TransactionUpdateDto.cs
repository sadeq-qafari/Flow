using Core.Meteor.Dto;

namespace Tenant.Operations.Transaction.Dtos
{
    public class TransactionUpdateInDto : DbUpdateInDto
    {
        public int PersonId { get; set; }
        public string Code { get; set; }
        public decimal Amount { get; set; }
        public bool IsDeposit { get; set; }
        public TransactionType TypeLookup { get; set; }
        public string? Description { get; set; }
    }
}
