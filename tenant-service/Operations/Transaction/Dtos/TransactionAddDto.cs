namespace Tenant.Operations.Transaction.Dtos
{
    public class TransactionAddInDto
    {
        public int PersonId { get; set; }
        public string Code { get; set; }
        public decimal Amount { get; set; }
        public bool IsDeposit { get; set; }
        public bool IsActive { get; set; }
        public TransactionType TypeLookup { get; set; }
        public string? Description { get; set; }
        public int CreatedBy { get; set; }
        public int? TenantId { get; set; }
    }

}
