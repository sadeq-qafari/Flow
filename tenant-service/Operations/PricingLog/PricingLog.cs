using NodaTime;
using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.PricingLog
{
    public class PricingLog : BaseModelDto, IDropDown
    {
        public int PricingItemId { get; set; }
        public float? Percent { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalCost { get; set; }
        public Instant Date { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
    }
}
