namespace Identity.Operations.Logic.Dto
{
    public class SendVerificationCodeInDto
    {
        public string MobileNumber { get; set; }
        public int? TenantId { get; set; }
        public string? TenantUrl { get; set; }
    }
}
