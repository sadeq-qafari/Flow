using System;

namespace Tenant.Operations.Transaction.Dtos
{
    public class TransactionTurnoverDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PersonTitle { get; set; }
        public DateTime? Date { get; set; }
        public TransactionType TypeLookup { get; set; }
        public string TypeLookupTitle { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
    }
}
