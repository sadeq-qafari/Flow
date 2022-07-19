using Core.Meteor.Dto;

namespace Tenant.Operations.Pricing.Dtos
{
    public class PricingAddInDto : DbInsertInDto
    {
        public int ApplicationId { get; set; }
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public decimal? FinalPrice { get; set; }
        public decimal? GiftAmount { get; set; }
        public int? Duration { get; set; }
        public string Description { get; set; }
    }
}
