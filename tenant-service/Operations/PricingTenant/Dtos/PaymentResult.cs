using NodaTime;

namespace Saanaa.Tenant.Operations.PricingTenant.Dtos
{
    public class PaymentResult
    {
        public PaymentInfo PaymentInfo { get; set; }
        public PaymentVerifyResult VerifyResult { get; set; }
    }

    public class PaymentInfo
    {
        public long GatewayDetailId { get; set; }
        public decimal TrackingNumber { get; set; }
        public decimal Amount { get; set; }
        public string Token { get; set; }
        public string TransactionCode { get; set; }
        public string GatewayName { get; set; }
        public string GatewayAccountName { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsPaid { get; set; }
        public long RequestId { get; set; }
        public string Code { get; set; }
        public Instant Date { get; set; }
        public bool IsDocumentRegistered { get; set; }
        public bool IsActive { get; set; }
        public dynamic Title { get; set; }
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedBy { get; set; }
        public dynamic ModifiedBy { get; set; }
        public Instant CreatedAt { get; set; }
        public Instant ModifiedAt { get; set; }
        public long TenantId { get; set; }
    }

    public class PaymentVerifyResult
    {
        public string TransactionCode { get; set; }
        public long Status { get; set; }
        public bool IsSucceed { get; set; }
        public decimal TrackingNumber { get; set; }
        public PaymentVerifyResultAmount Amount { get; set; }
        public string GatewayName { get; set; }
        public long GatewayAccountName { get; set; }
        public string Message { get; set; }
        public object AdditionalData { get; set; }
        public object DatabaseAdditionalData { get; set; }
    }

    public class PaymentVerifyResultAmount
    {
        public decimal Value { get; set; }
    }
}
