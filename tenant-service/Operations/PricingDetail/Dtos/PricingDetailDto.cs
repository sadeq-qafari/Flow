namespace Tenant.Operations.PricingDetail.Dtos
{
    public class PricingDetailDto : PricingDetail
    {
        public string? PricingTitle { get; set; }
        public string? PricingItemTitle { get; set; }
        public string? TypeLookupTitle { get; set; }
    }
}
