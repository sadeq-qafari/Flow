namespace Tenant.Operations.PricingDetailTenant.Dtos
{
    public class PricingDetailTenantDto : PricingDetailTenant
    {
        public string? PricingItemTitle { get; set; }
        public string? TenantTitle { get; set; }
    }
}
