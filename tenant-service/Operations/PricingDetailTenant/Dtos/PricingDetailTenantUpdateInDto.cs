using Meteor.Operation.Db.Default;
using Saanaa.Core.Meteor;

namespace Tenant.Operations.PricingDetailTenant.Dtos
{
    public class PricingDetailTenantUpdateInDto : IHaveModifiedBy, IDbModel<int>
    {
        public int Id { get; set; }
        public int PricingItemId { get; set; }
        public int PricingTenantId { get; set; }
        public decimal? Cost { get; set; }
        public float? Percent { get; set; }
        public decimal? FromPrice { get; set; }
        public decimal? ToPrice { get; set; }
        public int? ModifiedBy { get; set; }
        public int? TenantId { get; set; }
        public bool HasTenant0 { get; set; }
        public bool IsActive { get; set; }
    }
}
