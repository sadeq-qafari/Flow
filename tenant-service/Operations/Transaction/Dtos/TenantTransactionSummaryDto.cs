namespace Tenant.Operations.Transaction.Dtos
{
    public class TenantTransactionSummaryDto
    {
        public decimal? TotalIncome { get; set; }
        public decimal? TotalExpenses { get; set; }
        public decimal? Balance { get; set; }
    }
}