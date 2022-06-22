using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.PricingDetail.Dtos
{
    public class PricingDetailAddInDto : SaanaaDbInsertInDto
    {
        public int PricingId { get; set; }
        public int PricingItemId { get; set; }
        public int Quantity { get; set; }
        public decimal? Cost { get; set; }
        public float? Percent { get; set; }
        public decimal? FromPrice { get; set; }
        public decimal? ToPrice { get; set; }
        public int? TypeLookup { get; set; }
        public string Title { get; set; }
    }
}
