using Core.Meteor;
using Core.Meteor.Dto;

namespace Tenant.Operations.PricingDetailTenant
{
    public class PricingDetailTenant : BaseModelDto, IDropDown
    {
        public int PricingItemId { get; set; }
        public int PricingTenantId { get; set; }
        public decimal? Cost { get; set; }
        public float? Percent { get; set; }
        public decimal? FromPrice { get; set; }
        public decimal? ToPrice { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
    }
}
