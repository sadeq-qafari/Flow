using System;

namespace Tenant.Operations.Transaction.Dtos
{
    public class TenantTransactionInfoDto
    {
        public int? TransactionId { get; set; }
        public string PricingItemTitle { get; set; }
        public float? Percent { get; set; }
        public decimal Cost { get; set; }
        public decimal Discount { get; set; }
        public decimal? FinalCost { get; set; }
        public DateTime Date { get; set; }
    }
}