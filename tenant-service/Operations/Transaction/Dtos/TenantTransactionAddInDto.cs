namespace Tenant.Operations.Transaction.Dtos
{
    public class TenantTransactionAddInDto
    {
        public string Code { get; set; }
        public decimal Amount { get; set; }
        public decimal GiftAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public TransactionType TypeLookup { get; set; }
        public string? Description { get; set; }
        public int ActionBy { get; set; }
        public int? TenantId { get; set; }
    }
}
