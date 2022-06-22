using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingDetailTenant.Dtos
{
    public class PricingDetailTenantAddInDto : IHaveCreatedBy
    {
        public int PricingItemId { get; set; }
        public int PricingTenantId { get; set; }
        public decimal? Cost { get; set; }
        public float? Percent { get; set; }
        public decimal? FromPrice { get; set; }
        public decimal? ToPrice { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int TenantId { get; set; }


    }
}
