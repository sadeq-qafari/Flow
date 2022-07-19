using NodaTime;
using Core.Meteor.Dto;

namespace Tenant.Operations.PricingLog.Dtos
{
    public class PricingLogAddInDto : DbInsertInDto
    {
        public int PricingItemId { get; set; }
        public float? Percent { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public decimal Discount { get; set; }
        public Instant Date { get; set; }
        public int ModelId { get; set; }
        public int EntityId { get; set; }
    }
}
